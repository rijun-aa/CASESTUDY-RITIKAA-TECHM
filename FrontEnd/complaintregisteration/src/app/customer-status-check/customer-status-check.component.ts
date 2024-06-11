import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Complaint } from '../models/complaint.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-status-check',
  templateUrl: './customer-status-check.component.html',
  styleUrls: ['./customer-status-check.component.css']
})
export class CustomerStatusCheckComponent implements OnInit {
  complaints: Complaint[] = [];
  filteredComplaints: Complaint[] = [];
  searchTerm: string = '';

  constructor(private http: HttpClient, private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadComplaintsForLoggedInCustomer();
  }

  loadComplaintsForLoggedInCustomer() {
    const customerId = this.customerService.getCustomerId();
    if (customerId) {
      this.fetchComplaintsForCustomer(customerId);
    } else {
      console.error('No customer information available');
    }
  }

  fetchComplaintsForCustomer(customerId: number) {
    const url = `https://localhost:7028/api/Complaints?customerId=${customerId}`;
    this.http.get<Complaint[]>(url).subscribe({
      next: (complaints) => {
        this.complaints = complaints;
        this.filteredComplaints = complaints; // Initialize with all complaints
        this.filterComplaints(); // Apply initial filtering
      },
      error: (error) => {
        console.error('Error fetching complaints', error);
      }
    });
  }

  filterComplaints() {
    if (!this.searchTerm) {
      // Filter by customer IDy
      
      this.filteredComplaints = this.complaints.filter(complaint =>
        complaint.customerId === this.customerService.getCustomerId()
      );
    } else {
      // Filter by customer ID and search term
      this.filteredComplaints = this.complaints.filter(complaint =>
        complaint.customerId === this.customerService.getCustomerId() &&
        complaint.application?.applicationName.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }
}
