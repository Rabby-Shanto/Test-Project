import { Component } from '@angular/core';
import { CustomerManagementComponent } from "../customer-management/customer-management.component";
import { ProductManagementComponent } from "../product-management/product-management.component";
import { SummaryComponent } from "../summary/summary.component";

@Component({
    selector: 'app-base',
    standalone: true,
    templateUrl: './base.component.html',
    styleUrl: './base.component.css',
    imports: [CustomerManagementComponent, ProductManagementComponent, SummaryComponent]
})
export class BaseComponent {

}
