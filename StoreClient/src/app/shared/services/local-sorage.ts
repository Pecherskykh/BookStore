import { UserModelItem } from '../models/Users/user-model-item';
import { BehaviorSubject } from 'rxjs';

export class LocalSorage {
  setUser(user: UserModelItem) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser() {
    return JSON.parse(localStorage.getItem('user'));
  }
}
