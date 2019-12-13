import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './user-routing.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { UsersComponent } from './users/users.component';
import { MaterialModule } from '../material/material.module';
import { UpdateComponent } from './update/update.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ProfileComponent, UsersComponent, UpdateComponent],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class UserModule { }
