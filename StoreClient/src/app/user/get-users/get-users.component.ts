import { Component, OnInit } from '@angular/core';
import {UserService} from 'src/app/shared/services/user-service';
import {UserModelItem} from 'src/app/shared/models/Users/user-model-item';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css'],
  providers: [UserService]
})
export class GetUsersComponent implements OnInit {

  constructor(private userService: UserService) { }

  items: Array<UserModelItem>;

  GetUsers() {
    this.userService.getData().subscribe(data => {
      this.items = data.items;
  });
}

  ngOnInit() {
  }
}
