import { UserModelItem } from '../models/Users/user-model-item';

export class LocalSorage {
  setUser(user: UserModelItem) {
    localStorage.setItem('id', user.id.toString());
    localStorage.setItem('userName', user.userName);
    localStorage.setItem('firstName', user.firstName);
    localStorage.setItem('lastName', user.lastName);
    localStorage.setItem('email', user.email);
  }

  /*getUser(user: UserModelItem) {
    this.user.email = localStorage.getItem('email');
    //this.user.id = localStorage.getItem('id');
    this.user.firstName = localStorage.getItem('firstName');
    this.user.lastName = localStorage.getItem('lastName');
    this.user.userName = localStorage.getItem('userName');
  }*/
}
