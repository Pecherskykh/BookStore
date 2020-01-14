import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './cart-routing.module';
import { CartItemsComponent } from './cart-items/cart-items.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { PaymentSuccessComponent } from './payment-success/payment-success.component';


@NgModule({
  declarations: [CartItemsComponent, PaymentSuccessComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    CommonModule,
    MaterialModule
  ]
})
export class CartModule { }
