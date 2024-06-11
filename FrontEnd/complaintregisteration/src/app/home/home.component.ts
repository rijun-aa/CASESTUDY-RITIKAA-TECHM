import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../services/notification.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  notification: string | null = null;

  constructor(private router : Router ,private notificationService: NotificationService) { }

  ngOnInit(): void {
    console.log("hii");
    this.notification = this.notificationService.getNotification();
    console.log("hii");

  }


  closeNotification() {
    this.notification = null;
  }
  navigateTo(page: string) {
    this.router.navigate([page]);
  }
}
