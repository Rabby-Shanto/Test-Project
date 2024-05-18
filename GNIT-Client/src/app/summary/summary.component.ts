import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';
import { concatMap, catchError } from 'rxjs/operators';
import { forkJoin, throwError } from 'rxjs';

@Component({
  selector: 'app-summary',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './summary.component.html',
  styleUrl: './summary.component.css'
})
export class SummaryComponent implements OnInit {
  meetingData: any;
  addedProducts: any[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.meetingData = JSON.parse(localStorage.getItem('meetingData') ?? '');
    this.addedProducts = JSON.parse(localStorage.getItem('addedProducts') ?? '');
  }

  saveData() {
    const masterSave$ = this.saveMasterData();
    const productSave$ = this.saveProductData();

    forkJoin([masterSave$, productSave$]).subscribe(
      () => {},
      error => {
        console.error('Error saving meeting and product details:', error);
      },
      () => {
        alert('Data saved successfully');
        localStorage.removeItem('meetingData');
        localStorage.removeItem('addedProducts');
      }
    );
  }

  private saveMasterData() {
    const { year, month, day } = this.meetingData.meetingDate;
    const meetingTime = this.meetingData.meetingTime;
    const formattedMonth = month.toString().padStart(2, '0');
    const formattedDay = day.toString().padStart(2, '0');
    const [time, period] = meetingTime.split(' ');
    let [hours, minutes] = time.split(':').map(Number);
    if (period === 'PM' && hours < 12) {
        hours += 12;
    } else if (period === 'AM' && hours === 12) {
        hours = 0;
    }
    const formattedHours = hours.toString().padStart(2, '0');
    const formattedMinutes = minutes.toString().padStart(2, '0');
    const meetingDateTime = `${year}-${formattedMonth}-${formattedDay}T${formattedHours}:${formattedMinutes}:00`;
    console.log(meetingDateTime);

    const masterData = {
      customerName: this.meetingData.customerName,
      meetingTime: meetingDateTime,
      meetingPlace : this.meetingData.meetingPlace,
      attend : this.meetingData.attend,
      meetingAgenda : this.meetingData.meetingAgenda,
      meetingDiscussion : this.meetingData.meetingDiscussion,
      meetingDecision : this.meetingData.meetingDecision
    };

    return this.apiService.saveMeetingMaster(masterData);
  }

  private saveProductData() {
    const productObservables = this.addedProducts.map(product => {
      const productData = {
        name: product.productName,
        unit: product.unit,
        quantity: product.quantity
      };
      return this.apiService.saveMeetingDetails(productData).pipe(
        catchError(error => {
          console.error(`Error saving product ${product.productName}:`, error);
          return error;
        })
      );
    });

    return forkJoin(productObservables);
  }
}
