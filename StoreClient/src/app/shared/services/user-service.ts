import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {UserModel} from '../models/Users/user-model';
import {UserModelItem} from '../models/Users/user-model-item';
import { Observable, from } from 'rxjs';
import {UsersFilterModel} from 'src/app/shared/models/Users/users-filter-model';
import { environment } from 'src/environments/environment';

@Injectable()

export class UserService {

  constructor(private http: HttpClient) { }

  getUsers(usersFilterModel: UsersFilterModel): Observable<UserModel> {
    return this.http.post<UserModel>(
      `${environment.apiUrl}user/getUsers`,
      usersFilterModel
    );
  }

  changeUserStatus(element: string) {
    return this.http.get(`${environment.apiUrl}changeUserStatus?userId=${element}`);
  }

  update(element: UserModelItem) {
    return this.http.post(`${environment.apiUrl}user/update`, element);
  }

  remove(element: UserModelItem) {
    return this.http.post(`${environment.apiUrl}user/remove`, element);
  }

  testGet(): Observable<UserModelItem> {
    return this.http.get<UserModelItem>(`${environment.apiUrl}user/find`);
  }
}
