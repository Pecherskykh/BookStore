import { Component, OnInit } from '@angular/core';
import {UserService} from 'src/app/shared/services/user-service';
import {UserModelItem} from 'src/app/shared/models/Users/user-model-item';
import { FormControl } from '@angular/forms';
import {UsersFilterModel} from 'src/app/shared/models/Users/users-filter-model';
import {UserSortType} from 'src/app/shared/enums/user-sort-type';
import {UserStatus} from 'src/app/shared/enums/user-status';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';

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

  searchByName = new FormControl('');
  sortType = new FormControl('');
  sortingDirection = new FormControl('');
  userStatus = new FormControl('');

  GetUsers() {
    const usersFilterModel = new UsersFilterModel();
    usersFilterModel.searchString = this.searchByName.value;
    if (this.sortType.value === 'User name') {
      usersFilterModel.sortType = UserSortType.userName;
    }
    if (this.sortType.value === 'User Email') {
      usersFilterModel.sortType = UserSortType.email;
    }
    if (this.sortingDirection.value === 'Low To High') {
      usersFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (this.sortingDirection.value === 'High To Low') {
      usersFilterModel.sortingDirection = SortingDirection.highToLow;
    }
    if (this.userStatus.value === 'All') {
      usersFilterModel.userStatus = UserStatus.all;
    }
    if (this.userStatus.value === 'Active') {
      usersFilterModel.userStatus = UserStatus.active;
    }
    if (this.userStatus.value === 'Blocked') {
      usersFilterModel.userStatus = UserStatus.blocked;
    }
    usersFilterModel.pageSize = 10;
    usersFilterModel.pageCount = 1;
    this.userService.getUsers(usersFilterModel).subscribe(data => {
      this.items = data.items;
  });
}

  modal() {
    alert('starus');
    document.getElementById("m").style.display = 'block';
  }

  Edit(element: UserModelItem) {
    this.user = element;
    document.getElementById("back").style.display = 'block';
    document.getElementById("edit").style.display = 'block';
}

  cansel() {
    document.getElementById("back").style.display = 'none';
    document.getElementById("edit").style.display = 'none';
  }

  saveEditProfile()  {
    this.user.firstName = this.firstName.value;
    this.user.lastName = this.lastName.value;
    this.userService.UserUpdate(this.user).subscribe();
  }

  ChangeUserStatus(element: string) {
    this.userService.ChangeUserStatus(element).subscribe();
}

  Remove(element: number) {
    alert(element);
}
  ngOnInit() {
    const usersFilterModel = new UsersFilterModel();
    usersFilterModel.sortType = UserSortType.userName;
    usersFilterModel.sortingDirection = SortingDirection.lowToHigh;
    usersFilterModel.userStatus = UserStatus.all;
    usersFilterModel.pageSize = 10;
    usersFilterModel.pageCount = 1;
    this.userService.getUsers(usersFilterModel).subscribe(data => {
      this.items = data.items;
  });
  }
}
