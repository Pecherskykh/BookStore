import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetUsersComponent } from './get-users/get-users.component';
import { ProfileComponent } from './profile/profile.component';


export const routes: Routes = [
  { path: 'get-users', component: GetUsersComponent },
  { path: 'profile', component: ProfileComponent },
];
