import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './user-routing.module';
import { GetUsersComponent } from './get-users/get-users.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [GetUsersComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class UserModule { }
