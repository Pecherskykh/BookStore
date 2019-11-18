import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {UserModel} from '../models/Users/user-model';
import { Observable } from 'rxjs';

@Injectable()

export class UserService {

  constructor(private http: HttpClient) { }

  getData(): Observable<UserModel> {
    return this.http.post<UserModel>(
      'https://localhost:44319/api/user/getUsers',
      {
        sortType: 1,
        userStatus: 1,
        sortingDirection: 2,
        searchString: null,
        pageCount: 1,
        pageSize: 10
      }
    );
  }
}
