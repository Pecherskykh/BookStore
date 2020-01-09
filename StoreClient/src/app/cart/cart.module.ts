import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './cart-routing.module';
import { CartItemsComponent } from './cart-items/cart-items.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [CartItemsComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    CommonModule,
    MaterialModule
  ]
})
export class CartModule { }
