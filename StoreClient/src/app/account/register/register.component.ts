import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroupDirective, NgForm, FormGroup } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { MatDialog, ErrorStateMatcher } from '@angular/material';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

    return (invalidCtrl || invalidParent);
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AccontService]
})

export class RegisterComponent {

  registerForm: FormGroup;

  matcher = new MyErrorStateMatcher();

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
    });
  }

    checkPasswords(group: FormGroup) { // here we have the 'passwords' group
    let pass = group.controls.password.value;
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
