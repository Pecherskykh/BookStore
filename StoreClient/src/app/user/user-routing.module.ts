import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetUsersComponent } from './get-users/get-users.component';
import { ProfileComponent } from './profile/profile.component';
import { UsersComponent } from './users/users.component';

export const routes: Routes = [
  { path: 'get-users', component: GetUsersComponent },
  { path: 'users', component: UsersComponent },
  { path: 'profile', component: ProfileComponent },
];
