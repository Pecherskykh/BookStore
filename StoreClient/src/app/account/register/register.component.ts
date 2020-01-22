import { Component } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { MatDialog } from '@angular/material';
import { MyErrorStateMatcher } from 'src/app/shared/services/my-error-state-matcher';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AccontService]
})

export class RegisterComponent {

  registerForm: FormGroup;

  matcher: MyErrorStateMatcher;

  constructor(
    private accontService: AccontService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog) {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl(BaseConstants.stringEmpty, [Validators.required]),
      lastName: new FormControl(BaseConstants.stringEmpty, [Validators.required]),
      email: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.email]),
      newPassword: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')]),
      confirmPassword: new FormControl(BaseConstants.stringEmpty),
      userName: new FormControl(BaseConstants.stringEmpty, [Validators.required])
    }, { validator: this.checkPasswords });

    this.matcher = new MyErrorStateMatcher();
  }

    checkPasswords(group: FormGroup) {
    let pass = group.controls.newPassword.value;
    let confirmPass = group.controls.confirmPassword.value;

    return pass === confirmPass ? null : { notSame: true };
  }

    registration(baseModel: BaseModel): void {
    if (baseModel.errors.length > 0) {
      let dialogRef = this.dialog.open(ErrorListComponent, {data: baseModel.errors});
      return;
    }
    location.href = 'http://localhost:4200/account/confirm-email';
  }

  signUp(): void {
    this.accontService.register(this.registerForm.value).
    subscribe((data: BaseModel) => this.registration(data));
  }
}
