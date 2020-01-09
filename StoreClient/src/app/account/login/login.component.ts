import { Component} from '@angular/core';
import { AccontService } from 'src/app/shared/services/accont-service';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalSorage } from 'src/app/shared/services/local-sorage';
import { FormBuilder } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService, LocalSorage]
})

export class LoginComponent {

  loginForm;

  constructor(
    private accontService: AccontService,
    private localStorage: LocalSorage,
    private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      email: BaseConstants.stringEmpty,
      password: BaseConstants.stringEmpty
    });
  }

  Click() {
    alert(this.loginForm.value.email);
  }

    signIn(): void {
      this.accontService.postData(this.loginForm.value).
      subscribe((data: UserModelItem) => {
        this.localStorage.setUser(data);
        location.href = 'http://localhost:4200/user/profile';
      });
  }
}
