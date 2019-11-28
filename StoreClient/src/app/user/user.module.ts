import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './user-routing.module';
import { GetUsersComponent } from './get-users/get-users.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { UsersComponent } from './users/users.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [GetUsersComponent, ProfileComponent, UsersComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class UserModule { }
