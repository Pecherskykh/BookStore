import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {LoginModel} from 'src/app/shared/models/Login/login-model';
import { Observable } from 'rxjs';

@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }

    postData(loginModel: LoginModel) {
        return this.http.post<LoginModel>('https://localhost:44319/api/account/login', loginModel, { withCredentials: true });
    }

  ForgotPassword(email: string) {
      return this.http.get(`https://localhost:44319/api/account/forgotPassword?email=${email}`);
  }
}
