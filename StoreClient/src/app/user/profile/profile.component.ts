import { Component, OnInit } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { UserService } from 'src/app/shared/services/user-service';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { UserConstans } from 'src/app/shared/constans/user-constans';
import { Display } from 'src/app/shared/enums/display';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { MatDialog } from '@angular/material';
import { BaseModel } from 'src/app/shared/models/Base/base-model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService, LocalStorage]
})
export class ProfileComponent implements OnInit {

  user: UserModelItem;

  profileForm: FormGroup;
  passwordForm: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private localStorage: LocalStorage,
    private dialog: MatDialog
    ) {
    this.user = new UserModelItem();

    this.profileForm = this.formBuilder.group({
      firstName: new FormControl(BaseConstants.stringEmpty, [Validators.required]),
      lastName: new FormControl(BaseConstants.stringEmpty, [Validators.required]),
      email: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.email])
    });

    this.passwordForm =  this.formBuilder.group({
      currentPassword: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]),
      newPassword: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]),
      confirmPassword: new FormControl(BaseConstants.stringEmpty)
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

  authentication(user: UserModelItem): void {
    if (user.errors.length > 0) {
      let dialogRef = this.dialog.open(ErrorListComponent, {data: user.errors});
      return;
    }
    this.localStorage.setUser(user);
    location.href = 'http://localhost:4200/user/profile';
  }

  save() {
    this.user.firstName = this.profileForm.value.firstName;
    this.user.lastName = this.profileForm.value.lastName;
    this.user.email = this.profileForm.value.email;
    this.user.currentPassword = this.profileForm.value.currentPassword;
    this.user.newPassword = this.profileForm.value.newPassword;
    this.userService.update(this.user).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
      this.localStorage.setUser(this.user);
      this.initUser();
    });
  }

  initUser() {
    this.user = this.localStorage.getUser();
    if (this.user === null) {
      location.href = 'http://localhost:4200/account/login';
      return;
    }
    this.profileForm = this.formBuilder.group({
      firstName: new FormControl(this.user.firstName, [Validators.required]),
      lastName: new FormControl(this.user.lastName, [Validators.required]),
      email: new FormControl(this.user.email, [Validators.required, Validators.email])
    });
  }

  ngOnInit() {
    this.initUser();
  }
}
