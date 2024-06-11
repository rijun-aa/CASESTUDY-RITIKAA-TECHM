// customer.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Complaint, Customer } from '../models/complaint.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7028/api/Customers'; // Replace with your actual API URL
  private customer: Customer | null = null;

  constructor(private http: HttpClient) { }

  signup(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }

  login(email: string, password: string): Observable<Customer | null> {
    // Perform login HTTP request and retrieve customer ID upon successful login
    return this.http.post<Customer>('https://localhost:7028/api/Customers/login', { email, password });
  }

  setCustomer(customer: Customer) {
    this.customer = customer;
  }

  getCustomerId(): number | null {
    console.log(this.customer);
    return this.customer ? this.customer.customerid : null;}

    getClosedComplaints(customerId: number): Observable<Complaint[]> {
      return this.http.get<Complaint[]>(`${this.apiUrl}/${customerId}/closedComplaints`);
    }
    getComplaintsByCustomerId(customerId: number): Observable<Complaint[]> {
      return this.http.get<Complaint[]>(`${this.apiUrl}/${customerId}/complaints`);
    }
}
