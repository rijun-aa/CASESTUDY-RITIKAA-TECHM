// notification-popup.component.ts
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-notification-popup',
  templateUrl: './notification-popup.component.html',
  styleUrls: ['./notification-popup.component.css']
})
export class NotificationPopupComponent {
  @Input() message: string = '';
  isVisible: boolean = true;

  onClose(): void {
    this.isVisible = false;
  }
}
