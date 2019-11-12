import { Component} from '@angular/core';
import { HttpService} from './http.service';
import {User} from './user';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    providers: [HttpService]
})
export class AppComponent {

    user: User = new User();
    constructor(private httpService: HttpService) {}
    submit(user: User) {
      user.name = 'Name';
      user.password = 'password';
      this.httpService.postData(user).subscribe(data => {
        user = data;
      });
  }
}
