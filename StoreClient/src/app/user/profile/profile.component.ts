import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { UserService } from 'src/app/shared/services/user-service';
import { FormBuilder } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { UserConstans } from 'src/app/shared/constans/user-constans';
import { Display } from 'src/app/shared/enums/display';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService]
})
export class ProfileComponent implements OnInit {

  user: UserModelItem;

  profileForm;

  constructor(private userService: UserService, private formBuilder: FormBuilder) {
    this.user = new UserModelItem();

    this.profileForm = this.formBuilder.group({
      currentPassword: BaseConstants.stringEmpty,
      newPassword: BaseConstants.stringEmpty
    });
  }

  edit() {
    let element = document.getElementById(UserConstans.edit);
    element.style.display = Display[Display.block];
  }

  cansel() {
    let element = document.getElementById(UserConstans.edit);
    element.style.display = Display[Display.none];
  }

  save() {
    this.user.currentPassword = this.profileForm.value.currentPassword;
    this.user.newPassword = this.profileForm.value.newPassword;
    this.userService.update(this.user).subscribe();
  }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem(UserConstans.user));
    if (this.user === null) {
      location.href = 'http://localhost:4200/account/login';
    }
  }
}
