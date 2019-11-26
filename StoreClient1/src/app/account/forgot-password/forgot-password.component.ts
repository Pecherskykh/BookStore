import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import {AccontService} from 'src/app/shared/services/accont-service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers: [AccontService]
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private accontService: AccontService) { }

  email = new FormControl('');

  continue() {
    this.accontService.ForgotPassword(this.email.value).subscribe();
  }

  ngOnInit() {
  }

}
