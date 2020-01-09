import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {LoginModel} from 'src/app/shared/models/Login/login-model';
import { Observable } from 'rxjs';
import { UserModelItem } from '../models/Users/user-model-item';
import { BaseModel } from '../models/Base/base-model';
import { environment } from 'src/environments/environment';

@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }

    postData(loginModel: LoginModel): Observable<UserModelItem> {
        return this.http.post<UserModelItem>(`${environment.apiUrl}account/login`, loginModel, { withCredentials: true });
    }

    forgotPassword(email: string): Observable<BaseModel> {
        return this.http.get<BaseModel>(`${environment.apiUrl}account/forgotPassword?email=${email}`);
    }

    register(userModelItem: UserModelItem) {
        return this.http.post(`${environment.apiUrl}account/register`, userModelItem);
    }

    logOut() {
      return this.http.get(`${environment.apiUrl}account/logOut`);
    }
}
