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
import { UserConstans } from 'src/app/shared/constans/user-constans';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { UserModel } from 'src/app/shared/models/Users/user-model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {
  pageSizeOptions: number[];
  usersFilterModel: UsersFilterModel;
  count: number;
  pageIndex: number;
  displayedColumns: string[];
  items: Array<UserModelItem>;
  user: UserModelItem;
  userStatusItems: string[];

  searchByName: FormControl;
  userStatus: FormControl;

  constructor(private userService: UserService, public dialog: MatDialog) {
    this.usersFilterModel = new UsersFilterModel();
    this.usersFilterModel.sortType = UserSortType.userName;
    this.usersFilterModel.sortingDirection = SortingDirection.asc;
    this.usersFilterModel.userStatus = UserStatus.all;
    this.usersFilterModel.pageSize = BaseConstants.ten;
    this.usersFilterModel.pageCount = BaseConstants.zero;
    this.displayedColumns = DisplayedColumnsConstans.users;
    this.userStatusItems = UserConstans.userStatusItems;

    this.userStatus = new FormControl(this.userStatusItems);
    this.searchByName = new FormControl(BaseConstants.stringEmpty);
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers(this.usersFilterModel).subscribe((data: UserModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
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
    if (this.userStatus.value.length === 1 && this.userStatus.value[0] === this.userStatusItems[0]) {
      this.usersFilterModel.userStatus = UserStatus.active;
    }
    if (this.userStatus.value.length === 1 && this.userStatus.value[0] === this.userStatusItems[1]) {
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
  if (event.direction === SortingDirection[SortingDirection.asc]) {
    this.usersFilterModel.sortingDirection = SortingDirection.asc;
  }
  if (event.direction === SortingDirection[SortingDirection.desc]) {
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
    this.userService.changeUserStatus(element).subscribe((data: UserModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
    });
}

  remove(userModelItem: UserModelItem) {
    let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: UserConstans.user, name: userModelItem.firstName +
    ' ' + userModelItem.lastName}})
    .afterClosed().subscribe(data => {
      if (data) {
        this.userService.remove(userModelItem).subscribe((baseDate: BaseModel) => {
          if (baseDate.errors.length > 0) {
              let dialogRef = this.dialog.open(ErrorListComponent, {data: baseDate.errors});
              return;
            }
          });
        this.getUsers();
      }
    });
  }
}
