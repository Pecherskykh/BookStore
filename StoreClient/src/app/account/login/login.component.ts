import { Component} from '@angular/core';
import {LoginModel} from 'src/app/shared/models/Login/login-model';
import {AccontService} from 'src/app/shared/services/accont-service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService]
})

export class LoginComponent /*implements OnInit*/ {

  email = new FormControl('');
  password = new FormControl('');

    constructor(private accontService: AccontService) {}

    signIn() {
      // let loginModel = new LoginModel();
      // loginModel.email = this.email.value;
      // loginModel.password = this.password.value;
      this.accontService.postData({email: this.email.value, password: this.password.value}).subscribe();
  }
}
