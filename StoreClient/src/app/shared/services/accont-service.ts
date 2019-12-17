import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {LoginModel} from 'src/app/shared/models/Login/login-model';
import { Observable } from 'rxjs';
import { UserModelItem } from '../models/Users/user-model-item';

@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }

    postData(loginModel: LoginModel) {
        return this.http.post<LoginModel>('https://localhost:44319/api/account/login', loginModel, { withCredentials: true });
    }

  ForgotPassword(email: string) {
      return this.http.get(`https://localhost:44319/api/account/forgotPassword?email=${email}`);
  }

  register(userModelItem: UserModelItem) {
      return this.http.post('https://localhost:44319/api/account/register', userModelItem);
  }
}
