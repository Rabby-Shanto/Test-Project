import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Product } from '../interface/product';

@Component({
  selector: 'app-product-management',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent implements OnInit {
  products: Product[] = [];
  selectedProductId: number | null = null;
  unit: string = '';
  quantity: number = 1;
  addedProducts: any[] = [];

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
    this.getProductFromLocalHost();
  }

  loadProducts() {
    this.apiService.getProductsServices().subscribe((data: Product[]) => {
      this.products = data;
    });
  }

  onProductChange(event: any) {
    const selectedProduct = this.products.find(product => product.id === +event.target.value);
    this.unit = selectedProduct ? String(selectedProduct.unit) : '';
    this.selectedProductId = selectedProduct ? selectedProduct.id : null;
  }

  addProduct() {
    if (this.selectedProductId !== null) {
      const product = this.products.find(product => product.id === this.selectedProductId);
      if (product) {
        this.addedProducts.push({
          productName: product.name,
          unit: this.unit,
          quantity: this.quantity
        });
      }
    }
    this.quantity = 1;
  }

  editProduct(index: number) {
    const editedProduct = this.addedProducts[index];
    const originalProduct = this.products.find(p => p.name === editedProduct.productName);
    if (originalProduct) {
      this.addedProducts[index].unit = editedProduct.unit;
      this.addedProducts[index].quantity = editedProduct.quantity;
    }
  }

  deleteProduct(index: number) {
    this.addedProducts.splice(index, 1);
  }
  getProductFromLocalHost(){
    var data = localStorage.getItem('addedProducts');
    if(data){
      this.addedProducts = JSON.parse(data);
    }
  }

  next() {
    debugger;
    localStorage.setItem('addedProducts', JSON.stringify(this.addedProducts));
  }
}
