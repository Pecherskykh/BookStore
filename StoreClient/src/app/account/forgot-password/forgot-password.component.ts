import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseModel } from 'src/app/shared/models/Base/base-model';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers: [AccontService]
})
export class ForgotPasswordComponent {

  email: FormControl;
  errors: Array<string>;

  constructor(private accontService: AccontService) {
    this.email = new FormControl();
  }

  continue(): void {
    this.accontService.forgotPassword(this.email.value).subscribe((data: BaseModel) => {
      this.errors = data.errors;
    });
  }
}
