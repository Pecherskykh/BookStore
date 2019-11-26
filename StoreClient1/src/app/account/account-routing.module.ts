import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LogOutComponent } from './log-out/log-out.component';
import { RefreshTokensComponent } from './refresh-tokens/refresh-tokens.component';
import { RegisterComponent } from './register/register.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'confirm-email', component: ConfirmEmailComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'log-out', component: LogOutComponent },
  { path: 'refresh-tokens', component: RefreshTokensComponent },
  { path: 'register', component: RegisterComponent }
];
