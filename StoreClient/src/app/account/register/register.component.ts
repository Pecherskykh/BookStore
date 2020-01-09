import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseConstants } from 'src/app/shared/constans/base-constants';

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
      password: BaseConstants.stringEmpty,
      userName: BaseConstants.stringEmpty
    });
  }

  signUp(): void {
    this.accontService.register(this.registerForm.value).
    subscribe(() => location.href = 'http://localhost:4200/account/confirm-email');
  }
}
