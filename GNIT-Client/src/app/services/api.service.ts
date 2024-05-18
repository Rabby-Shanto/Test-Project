import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Corporate } from '../interface/corporate';
import { Product } from '../interface/product';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  public baseUrl = 'http://localhost:5177';

  getCorporateCustomers(): Observable<Corporate[]> {
    return this.http.get<any[]>(this.baseUrl + '/api/CorporateApi').pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  getIndividualCustomers(): Observable<any[]> {
    return this.http.get<any[]>('api/individual-customers');
  }

  getProductsServices(): Observable<Product[]> {
    debugger;
    return this.http.get<any[]>(this.baseUrl + '/api/Product').pipe(
      map((data: any) => {
        console.log("Get Data",data);
        return data;
      })
    );
  }

  saveMeetingMaster(data: any): Observable<any> {
    return this.http.post(this.baseUrl + '/api/CorporateApi', data);
  }

  saveMeetingDetails(data: any): Observable<any> {
    return this.http.post(this.baseUrl + '/api/Product', data);
  }
}
