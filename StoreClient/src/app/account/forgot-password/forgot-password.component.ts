import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccontService } from 'src/app/shared/services/accont-service';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { MatDialog } from '@angular/material';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { BaseConstants } from 'src/app/shared/constans/base-constants';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers: [AccontService]
})
export class ForgotPasswordComponent {

  email: FormControl;
  errors: Array<string>;

  constructor(private accontService: AccontService, private dialog: MatDialog) {
    this.email = new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.email]);
  }

  continue(): void {
    this.accontService.forgotPassword(this.email.value).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
      }
    });
  }
}
