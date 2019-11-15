import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '../models/user';
import { Observable } from 'rxjs';

@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }

    postData(user: User): Observable<User> {
        return this.http.post<User>('https://localhost:44319/api/account/login', user, { withCredentials: true });
    }

    getData(accessToken: string): Observable<User> {
      return this.http.get<User>(
        'https://localhost:44319/api/account/testGet',
        {
          headers: new HttpHeaders().set('Authorization', `Bearer ${accessToken}`)
        }
      );
  }
  ForgotPassword(email: string) {
      return this.http.post(`https://localhost:44319/api/account/forgotPassword?email=${email}`, null);
  }
}
