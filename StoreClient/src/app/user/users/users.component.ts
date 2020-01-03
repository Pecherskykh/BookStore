import { Component, OnInit } from '@angular/core';
import {UserService} from 'src/app/shared/services/user-service';
import {UserModelItem} from 'src/app/shared/models/Users/user-model-item';
import { FormControl } from '@angular/forms';
import {UsersFilterModel} from 'src/app/shared/models/Users/users-filter-model';
import {UserSortType} from 'src/app/shared/enums/user-sort-type';
import {UserStatus} from 'src/app/shared/enums/user-status';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import { MatSort, PageEvent, MatDialog } from '@angular/material';
import { UpdateComponent } from '../update/update.component';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  usersFilterModel: UsersFilterModel;
  count: number;
  pageIndex: number;
  displayedColumns: string[];
  items: Array<UserModelItem>;
  user: UserModelItem;
  searchByName = new FormControl('');
  userStatusItems: string[] = ['Active', 'Blocked'];
  userStatus = new FormControl(this.userStatusItems);

  constructor(private userService: UserService, public dialog: MatDialog) {
    this.usersFilterModel = new UsersFilterModel();
    this.usersFilterModel.sortType = UserSortType.userName;
    this.usersFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.usersFilterModel.userStatus = UserStatus.all;
    this.usersFilterModel.pageSize = 10;
    this.usersFilterModel.pageCount = 0;
    this.displayedColumns = DisplayedColumnsConstans.users;
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers(this.usersFilterModel).subscribe(data => {
      this.count = data.count;
      this.items = data.items;
  });
}

  filterUsers() {
    this.pageIndex = 0;
    this.usersFilterModel.pageCount = 0;
    this.usersFilterModel.searchString = this.searchByName.value;

    if (this.userStatus.value.length === 2) {
      this.usersFilterModel.userStatus = UserStatus.all;
    }
    if (this.userStatus.value.length === 1 && this.userStatus.value[0] === 'Active') {
      this.usersFilterModel.userStatus = UserStatus.active;
    }
    if (this.userStatus.value.length === 1 && this.userStatus.value[0] === 'Blocked') {
      this.usersFilterModel.userStatus = UserStatus.blocked;
    }

    this.getUsers();
}

  edit(userModelItem: UserModelItem) {
    const dialogRef = this.dialog.open(UpdateComponent, {data: userModelItem});
}

sortData(event: MatSort) {
  if (event.active === UserSortType[UserSortType.userName]) {
    this.usersFilterModel.sortType = UserSortType.userName;
  }

  if (event.active === UserSortType[UserSortType.email]) {
    this.usersFilterModel.sortType = UserSortType.email;
  }
  if (event.direction === 'asc') {
    this.usersFilterModel.sortingDirection = SortingDirection.asc;
  }
  if (event.direction === 'desc') {
    this.usersFilterModel.sortingDirection = SortingDirection.desc;
  }
  this.getUsers();
}

getServerData(event: PageEvent) {
  this.pageIndex = event.pageIndex;
  this.usersFilterModel.pageSize = event.pageSize;
  this.usersFilterModel.pageCount = this.pageIndex;
  this.getUsers();
}

  changeUserStatus(element: string) {
    this.userService.changeUserStatus(element).subscribe();
}

  remove(userModelItem: UserModelItem) {
    let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: 'user', name: userModelItem.firstName +
    ' ' + userModelItem.lastName}})
    .afterClosed().subscribe(data => {
      if (data) {
        this.userService.remove(userModelItem).subscribe(() => this.getUsers());
      }
    });
  }
}
