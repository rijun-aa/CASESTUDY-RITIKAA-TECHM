import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notificationKey = 'userNotification';

  setNotification(message: string) {
    localStorage.setItem(this.notificationKey, message);
  }

  getNotification(): string | null {
    const message = localStorage.getItem(this.notificationKey);
    if (message) {
     // console.log(message);

      localStorage.removeItem(this.notificationKey); // Clear notification after fetching
    }
    return message;
  }
}
