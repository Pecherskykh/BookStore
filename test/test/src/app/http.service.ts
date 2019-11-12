import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from './user';
import { ObservedValueOf, Observable } from 'rxjs';
@Injectable()

export class HttpService {
    constructor(private http: HttpClient) { }
    postData(user: User): Observable<User> {
        //let body = {name: user.name, password: user.password};
        //alert(body.name + ' ' + body.password);
        return this.http.post<User>('https://localhost:44323/api/account/testPost', user, { withCredentials: true });
    }
}
