import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routes } from './account-routing.module';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';

@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule, MaterialModule, CommonModule],
  declarations: [LoginComponent, ConfirmEmailComponent, ForgotPasswordComponent, RegisterComponent]
})
export class AccountModule { }
