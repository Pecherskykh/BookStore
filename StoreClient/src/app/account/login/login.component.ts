import { Component} from '@angular/core';
import { AccontService } from 'src/app/shared/services/accont-service';
import { FormControl } from '@angular/forms';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalSorage } from 'src/app/shared/services/local-sorage';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService, LocalSorage]
})

export class LoginComponent {

  email: FormControl;
  password: FormControl;

  constructor(private accontService: AccontService, private localStorage: LocalSorage) {
    this.email = new FormControl('');
    this.password = new FormControl('');
  }

    signIn() {
      this.accontService.postData({email: this.email.value, password: this.password.value}).subscribe((data: UserModelItem) => {
        this.localStorage.setUser(data);
        location.href = 'http://localhost:4200/user/profile';
      });
  }
}
