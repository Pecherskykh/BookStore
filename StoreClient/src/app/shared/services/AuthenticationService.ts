import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { BaseModel } from '../models/Base/base-model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class AuthenticationService {
  constructor(private cookieService: CookieService, private http: HttpClient) { }
  getJwtToken() {
    let a = this.cookieService.get('accessToken');
    return a;
  }

  refreshToken(): Observable<BaseModel> {
    let refresh = this.cookieService.get('refreshToken');
    return this.http.get<BaseModel>(`${environment.apiUrl}account/refreshTokens?refreshToken=${refresh}`, { withCredentials: true });
  }
}
