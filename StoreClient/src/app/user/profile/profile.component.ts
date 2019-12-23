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
  currentPassword = new FormControl('');
  newPassword = new FormControl('');

  constructor(private userService: UserService) {
    this.user = new UserModelItem();
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
    this.user.email = localStorage.getItem('email');
    //this.user.id = localStorage.getItem('id');
    this.user.firstName = localStorage.getItem('firstName');
    this.user.lastName = localStorage.getItem('lastName');
    this.user.userName = localStorage.getItem('userName');
    //this.userService.testGet().subscribe((data: UserModelItem) => this.user = data);
  }
}
