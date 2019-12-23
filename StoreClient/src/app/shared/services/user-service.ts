import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {UserModel} from '../models/Users/user-model';
import {UserModelItem} from '../models/Users/user-model-item';
import { Observable, from } from 'rxjs';
import {UsersFilterModel} from 'src/app/shared/models/Users/users-filter-model';

@Injectable()

export class UserService {

  constructor(private http: HttpClient) { }

  getUsers(usersFilterModel: UsersFilterModel): Observable<UserModel> {
    return this.http.post<UserModel>(
      'https://localhost:44319/api/user/getUsers',
      usersFilterModel
    );
  }

  changeUserStatus(element: string) {
    return this.http.get(`https://localhost:44319/api/user/changeUserStatus?userId=${element}`);
  }

  update(element: UserModelItem) {
    return this.http.post('https://localhost:44319/api/user/update', element);
  }

  remove(element: UserModelItem) {
    return this.http.post('https://localhost:44319/api/user/remove', element);
  }

  testGet(): Observable<UserModelItem> {
    return this.http.get<UserModelItem>('https://localhost:44319/api/user/find');
  }
}
