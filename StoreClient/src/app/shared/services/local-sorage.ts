import { UserModelItem } from '../models/Users/user-model-item';
import { BehaviorSubject } from 'rxjs';

export class LocalSorage {
  setUser(user: UserModelItem) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser() {
    debugger;
    return JSON.parse(localStorage.getItem('user'));
  }

  /*getUser(user: UserModelItem) {
    this.user.email = localStorage.getItem('email');
    //this.user.id = localStorage.getItem('id');
    this.user.firstName = localStorage.getItem('firstName');
    this.user.lastName = localStorage.getItem('lastName');
    this.user.userName = localStorage.getItem('userName');
  }*/
}
