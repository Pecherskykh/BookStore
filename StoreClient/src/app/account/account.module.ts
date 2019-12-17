import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routes } from './account-routing.module';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LogOutComponent } from './log-out/log-out.component';
import { RefreshTokensComponent } from './refresh-tokens/refresh-tokens.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';

@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule, MaterialModule],
  declarations: [LoginComponent, ConfirmEmailComponent, ForgotPasswordComponent, LogOutComponent, RefreshTokensComponent, RegisterComponent]
})
export class AccountModule { }
