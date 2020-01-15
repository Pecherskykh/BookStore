import { Component} from '@angular/core';
import { AccontService } from 'src/app/shared/services/accont-service';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { FormBuilder } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService, LocalStorage]
})

export class LoginComponent {

  loginForm;

  constructor(
    private accontService: AccontService,
    private localStorage: LocalStorage,
    private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      email: BaseConstants.stringEmpty,
      password: BaseConstants.stringEmpty
    });
  }

  Click() {
    alert(this.loginForm.value.email);
  }

  authentication(user: UserModelItem): void {
    if (user.errors.length !== 0) {
      alert(user.errors[0]);
      return;
    }
    this.localStorage.setUser(user);
    location.href = 'http://localhost:4200/user/profile';
  }

    signIn(): void {
      this.accontService.postData(this.loginForm.value).
      subscribe((data: UserModelItem) => {
        this.authentication(data);
      });
  }
}
