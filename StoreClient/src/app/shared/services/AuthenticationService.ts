import {Injectable} from '@angular/core';
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

  deleteCookie() {
    this.cookieService.deleteAll();
    this.cookieService.set(accessToken, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJmMDI5OTQ2YS0xYTU4LTQyNzctYmE0NC0xNDY3MDllNDJlNDAiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjU0IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJOYW1lIiwiZXhwIjoxNTc5Nzg0MTI3LCJpc3MiOiJNeUF1dGhTZXJ2ZXIiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyOTc2In0.fQ0QRqXF15EvIxT5pLAaikQ4QpA9Rjiw6ndKOzdbYcA');
  }
}
