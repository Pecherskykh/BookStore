import { Component} from '@angular/core';
import {LoginModel} from 'src/app/shared/models/Login/login-model';
import {AccontService} from 'src/app/shared/services/accont-service';
import { FormControl } from '@angular/forms';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalSorage } from 'src/app/shared/services/local-sorage';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService, LocalSorage]
})

export class LoginComponent /*implements OnInit*/ {


  email = new FormControl('');
  password = new FormControl('');

    constructor(private accontService: AccontService, private localStorage1: LocalSorage) {}

    signIn() {
      // let loginModel = new LoginModel();
      // loginModel.email = this.email.value;
      // loginModel.password = this.password.value;
      this.accontService.postData({email: this.email.value, password: this.password.value}).subscribe((data: UserModelItem) => {
        this.localStorage1.setUser(data);
      });
      //localStorage.clear();
  }
}
