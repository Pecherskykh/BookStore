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

  /*er(baseModel: BaseModel) {
    if (baseModel.errors.length !== 0) {
      alert(baseModel.errors[0]);
    }
  }*/

  continue(): void {
    this.accontService.forgotPassword(this.email.value).subscribe((data: BaseModel) => {
      if (data.errors.length !== 0) {
        alert(data.errors[0]);
      }
    });
  }
}
