import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpInterceptor } from '@angular/common/http';
import { switchMap, filter, take, catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject, throwError } from 'rxjs';
import { AuthenticationService } from '../services/AuthenticationService';

@Injectable()

export class Interceptor implements HttpInterceptor {

  constructor(public authenticationService: AuthenticationService) { }
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (this.authenticationService.getJwtToken()) {
      request = this.addToken(request, this.authenticationService.getJwtToken());
    }

    return next.handle(request).pipe(catchError(error => {
      debugger;
      if (error instanceof HttpErrorResponse && error.status === 401) {
        return this.handle401Error(request, next);
      } else {
        return throwError(error);
      }
    }));

    /*return next.handle(request).pipe(catchError(error => {
      if (error instanceof HttpErrorResponse && error.status === 401) {
        return this.handle401Error(request, next);
      } else {
        return throwError(error);
      }
    }));*/
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
  debugger;
  this.authenticationService.refreshToken().subscribe();
  this.intercept(request, next);
  }
}
