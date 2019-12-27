import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderManagmentComponent } from './order-managment/order-managment.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';

export const routes: Routes = [
  { path: 'order-managment', component: OrderManagmentComponent },
  { path: 'my-orders', component: MyOrdersComponent }
];
