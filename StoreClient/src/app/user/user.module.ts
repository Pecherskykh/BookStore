import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './user-routing.module';
import { GetUsersComponent } from './get-users/get-users.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [GetUsersComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ]
})
export class UserModule { }
