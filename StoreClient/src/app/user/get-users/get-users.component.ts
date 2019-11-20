import { Component, OnInit } from '@angular/core';
import {UserService} from 'src/app/shared/services/user-service';
import {UserModelItem} from 'src/app/shared/models/Users/user-model-item';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css'],
  providers: [UserService]
})
export class GetUsersComponent implements OnInit {

  constructor(private userService: UserService) { }

  items: Array<UserModelItem>;
  user: UserModelItem;
  firstName = new FormControl('');
  lastName = new FormControl('');

  GetUsers() {
    this.userService.getData().subscribe(data => {
      this.items = data.items;
  });
}

  modal() {
    alert('starus');
    document.getElementById("m").style.display = 'block';
  }

  Edit(element: UserModelItem){
    this.user = element;
    document.getElementById("back").style.display = 'block';
    document.getElementById("edit").style.display = 'block';
}

  cansel() {
    document.getElementById("back").style.display = 'none';
    document.getElementById("edit").style.display = 'none';
  }

  saveEditProfile()
  {
    this.user.firstName = this.firstName.value;
    this.user.lastName = this.lastName.value;
    this.userService.UserUpdate(this.user).subscribe();
  }

  ChangeUserStatus(element: string){    
    this.userService.ChangeUserStatus(element).subscribe();
}

  Remove(element: number){
    alert(element);
}
  ngOnInit() {
    this.userService.getData().subscribe(data => {
      this.items = data.items;
  });
  }
}
