import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { AccontService } from 'src/app/shared/services/accont-service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AccontService]
})
export class RegisterComponent implements OnInit {

  userName: FormControl;
  firstName: FormControl;
  lastName: FormControl;
  email: FormControl;
  password: FormControl;

  constructor(private accontService: AccontService) {
    this.firstName = new FormControl('');
    this.lastName = new FormControl('');
    this.email = new FormControl('');
    this.password = new FormControl('');
    this.userName = new FormControl('');
  }

  signUp() {
    let userModelItem = new UserModelItem();
    userModelItem.userName = this.userName.value;
    userModelItem.firstName = this.firstName.value;
    userModelItem.lastName = this.lastName.value;
    userModelItem.email = this.email.value;
    userModelItem.password = this.password.value;
    this.accontService.register(userModelItem).subscribe();
  }

  ngOnInit() {
  }

}
