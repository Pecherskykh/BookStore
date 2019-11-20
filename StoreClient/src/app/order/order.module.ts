import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routes } from './order-routing.module';
import { OrderManagmentComponent } from './order-managment/order-managment.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [OrderManagmentComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,

  ]
})
export class OrderModule { }
