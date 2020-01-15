import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { BaseModel } from 'src/app/shared/models/Base/base-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AccontService]
})

export class RegisterComponent {

  registerForm;

  constructor(private accontService: AccontService, private formBuilder: FormBuilder) {
    this.registerForm = this.formBuilder.group({
      firstName: BaseConstants.stringEmpty,
      lastName: BaseConstants.stringEmpty,
      email: BaseConstants.stringEmpty,
      newPassword: BaseConstants.stringEmpty,
      userName: BaseConstants.stringEmpty
    });
  }

    registration(user: BaseModel): void {
    if (user.errors.length !== 0) {
      alert(user.errors[0]);
      return;
    }
    location.href = 'http://localhost:4200/account/confirm-email';
  }

  signUp(): void {
    debugger;
    this.accontService.register(this.registerForm.value).
    subscribe((data: BaseModel) => this.registration(data));
  }
}
