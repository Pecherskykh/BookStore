import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {User} from 'src/app/shared/models/user';
import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
@Injectable()

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  constructor() { }

  private http: HttpClient;

  login(email: string, passwor: string): Observable<User> {
    alert('fdgdf');
    return this.http.post<User>('http://localhost:52976/api/account/login', {
      userName: email,
      password: passwor
    });
  }

  OnClick() {
    this.login('fdsfsd', 'fdfsf');
  }
  ngOnInit() {
  }
}
