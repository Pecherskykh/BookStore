import { Component, OnInit } from '@angular/core';
import { AccontService } from '../../services/accont-service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [AccontService]
})
export class HeaderComponent implements OnInit {

  constructor(private accontService: AccontService) { }

  logOut() {
    localStorage.removeItem('user');
    this.accontService.logOut();
    location.href = 'http://localhost:4200/account/login';
  }

  ngOnInit() {
  }
}
