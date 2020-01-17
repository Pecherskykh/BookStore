import { Component} from '@angular/core';
import { AccontService } from 'src/app/shared/services/accont-service';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccontService, LocalStorage]
})

export class LoginComponent {

  loginForm;

  constructor(
    private accontService: AccontService,
    private localStorage: LocalStorage,
    private formBuilder: FormBuilder,
    private dialog: MatDialog) {
    this.loginForm = this.formBuilder.group({
      email: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.email]),
      password: new FormControl(BaseConstants.stringEmpty, [Validators.required, Validators.minLength(8),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$')])
    });
  }

  Click() {
    alert(this.loginForm.value.email);
  }

  authentication(user: UserModelItem): void {
    if (user.errors.length > 0) {
      let dialogRef = this.dialog.open(ErrorListComponent, {data: user.errors});
      return;
    }
    this.localStorage.setUser(user);
    location.href = 'http://localhost:4200/user/profile';
  }

    signIn(): void {
      this.accontService.postData(this.loginForm.value).
      subscribe((data: UserModelItem) => {
        this.authentication(data);
      });
  }
}
