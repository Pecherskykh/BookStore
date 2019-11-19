import { Component} from '@angular/core';
import {User} from 'src/app/shared/models/user';
import {AccontService} from 'src/app/shared/services/accont-service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService]
})

export class LoginComponent /*implements OnInit*/ {

  userName = new FormControl('');
  password = new FormControl('');

  user: User = new User();

    constructor(private accontService: AccontService) {}

    signIn(user: User) {
      user.userName = this.userName.value;
      user.password = this.password.value;
      this.accontService.postData(user).subscribe(data => {
        user = data;
      });
  }
}
