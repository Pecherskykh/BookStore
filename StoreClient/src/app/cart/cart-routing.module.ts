import { CartItemsComponent } from './cart-items/cart-items.component';
import { Routes } from '@angular/router';
import { PaymentSuccessComponent } from './payment-success/payment-success.component';

export const routes: Routes = [
  {path: 'cart-items', component: CartItemsComponent },
  {path: 'payment-success', component: PaymentSuccessComponent }
];
