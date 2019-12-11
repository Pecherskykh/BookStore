import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routes } from './order-routing.module';
import { OrderManagmentComponent } from './order-managment/order-managment.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [OrderManagmentComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class OrderModule { }
