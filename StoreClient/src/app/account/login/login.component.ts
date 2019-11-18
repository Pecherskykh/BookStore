import { Component} from '@angular/core';
import {User} from 'src/app/shared/models/user';
import {AccontService} from 'src/app/shared/services/accont-service';
import { FormControl } from '@angular/forms';
import {CookieService} from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService]
})

export class LoginComponent /*implements OnInit*/ {

  userName = new FormControl('');
  password = new FormControl('');

  accessToken: string = this.cookieService.get('accessToken');
  user: User = new User();

    constructor(private accontService: AccontService, private cookieService: CookieService) {}

    signIn(user: User) {
      user.userName = this.userName.value;
      user.password = this.password.value;
      this.accontService.postData(user).subscribe(data => {
        user = data;
      });
  }

    signUp() {
      this.accontService.getData(this.accessToken).subscribe(data => {
        document.getElementById('j').innerHTML = ' ' + data.userName + ' ' + data.password;
      });
  }
}
