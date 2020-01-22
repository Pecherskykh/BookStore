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
import { MyErrorStateMatcher } from 'src/app/shared/services/my-error-state-matcher';

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
  changePhotoDisplayNone: boolean;
  matcher: MyErrorStateMatcher;

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
      currentPassword: new FormControl(BaseConstants.stringEmpty, [Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]),
      newPassword: new FormControl(BaseConstants.stringEmpty, [Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]),
      confirmPassword: new FormControl(BaseConstants.stringEmpty)
    }, { validator: this.checkPasswords });

    this.matcher = new MyErrorStateMatcher();
    this.changePhotoDisplayNone = true;
  }

  checkPasswords(group: FormGroup) {
    let pass = group.controls.newPassword.value;
    let confirmPass = group.controls.confirmPassword.value;

    return pass === confirmPass ? null : { notSame: true };
  }

  changePhoto(): void {
    this.changePhotoDisplayNone = !this.changePhotoDisplayNone;
    let element = document.getElementById('change__photo');

    if (this.changePhotoDisplayNone) {
      element.style.display = Display[Display.block];
      return;
    }

    if (!this.changePhotoDisplayNone) {
      element.style.display = Display[Display.none];
      return;
    }
  }

  change(event) {
    debugger;
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    this.user.photo = reader.result.toString();
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
    this.user.currentPassword = this.passwordForm.value.currentPassword;
    this.user.newPassword = this.passwordForm.value.newPassword;
    this.userService.update(this.user).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
      this.localStorage.setUser(this.user);
      location.reload();
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
