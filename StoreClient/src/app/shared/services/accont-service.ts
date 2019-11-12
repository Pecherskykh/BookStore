import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../models/user';
import { ObservedValueOf, Observable } from 'rxjs';
@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }
    postData(user: User): Observable<User> {
        //let body = {name: user.name, password: user.password};
        return this.http.post<User>('https://localhost:44323/api/account/login', user, { withCredentials: true });
    }
}
