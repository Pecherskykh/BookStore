import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { UsersComponent } from './users/users.component';
import { UpdateComponent } from './update/update.component';

export const routes: Routes = [
  { path: 'users', component: UsersComponent },
  { path: 'update', component: UpdateComponent },
  { path: 'profile', component: ProfileComponent }
];
