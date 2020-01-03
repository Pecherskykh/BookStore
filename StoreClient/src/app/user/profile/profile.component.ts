import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { UserService } from 'src/app/shared/services/user-service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService]
})
export class ProfileComponent implements OnInit {

  user: UserModelItem;
  currentPassword: FormControl;
  newPassword: FormControl;

  constructor(private userService: UserService) {
    this.user = new UserModelItem();
    this.currentPassword = new FormControl('');
    this.newPassword = new FormControl('');
  }

  edit() {
    let element = document.getElementById('edit');
    element.style.display = 'block';
  }

  cansel() {
    let element = document.getElementById('edit');
    element.style.display = 'none';
  }

  save() {
    this.user.currentPassword = this.currentPassword.value;
    this.user.newPassword = this.newPassword.value;
    this.userService.update(this.user).subscribe();
  }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'));
    if (this.user === null) {
      location.href = 'http://localhost:4200/account/login';
    }
  }
}
