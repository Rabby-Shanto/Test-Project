import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerConfig, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { Corporate } from '../interface/corporate';

@Component({
  selector: 'app-customer-management',
  standalone: true,
  imports: [
    FormsModule, 
    NgbDatepickerModule
  ],
  templateUrl: './customer-management.component.html',
  styleUrl: './customer-management.component.css'
})
export class CustomerManagementComponent implements OnInit {
  customerType: string = 'Corporate';
  customers: Corporate[] = [];
  selectedCustomer: Corporate | null = null;
  meetingDate: any = null;
  meetingTime: string = '';
  meetingPlace: string = '';
  clientAttendees: string = '';
  hostAttendees: string = '';
  meetingAgenda: string = '';
  meetingDiscussion: string = '';
  meetingDecision: string = '';
  isDatepickerOpen: boolean = false

  constructor(private apiService: ApiService, private router: Router, private config: NgbDatepickerConfig) {
    config.minDate = { year: 1950, month: 1, day: 1 };
    config.maxDate = { year: 2024, month: 12, day: 31 };
    config.outsideDays = 'hidden';
  }

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers() {
    const apiCall = this.customerType === 'Corporate' 
      ? this.apiService.getCorporateCustomers()
      : this.apiService.getIndividualCustomers();

    apiCall.subscribe((data: Corporate[]) => {
      this.customers = data;
    });
  }

  toggleDatepicker() {
    this.isDatepickerOpen = !this.isDatepickerOpen;
  }

  onDateChange(newDate: any) {
    this.meetingDate = newDate;
  }

  next() {

    const meetingData = {
      customerName: this.selectedCustomer,
      meetingDate: this.meetingDate,
      meetingTime: this.formatTime(this.meetingTime),
      meetingPlace: this.meetingPlace,
      clientAttendees: this.clientAttendees,
      hostAttendees: this.hostAttendees,
      meetingAgenda: this.meetingAgenda,
      meetingDiscussion: this.meetingDiscussion,
      meetingDecision: this.meetingDecision
    };
    localStorage.setItem('meetingData', JSON.stringify(meetingData));
  }

  onTimeChange(event: Event) {
    this.meetingTime = (event.target as HTMLInputElement).value;
  }

  formatTime(time: string): string {
    if (!time) return ''; 
    const [hours, minutes] = time.split(':').map(Number);
    const meridian = hours >= 12 ? 'PM' : 'AM';
    const formattedHours = hours % 12 || 12;
    return `${formattedHours}:${minutes < 10 ? '0' : ''}${minutes} ${meridian}`;
  }
}
