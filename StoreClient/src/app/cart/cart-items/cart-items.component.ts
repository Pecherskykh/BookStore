import { Component, OnInit, Predicate } from '@angular/core';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';
import { OrderItemModelItem } from 'src/app/shared/models/OrderItem/order-item-model-item';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { CartModel } from 'src/app/shared/models/Cart/cart-model';
import { CartService } from 'src/app/shared/services/cart-service';
import { PaymentService } from 'src/app/shared/services/payment-service';
import { MatDialog } from '@angular/material';
import { PaymentSuccessComponent } from '../payment-success/payment-success.component';
import { OrderManagmentModelItem } from 'src/app/shared/models/Orders/order-managment-model-item';

@Component({
  selector: 'app-cart-items',
  templateUrl: './cart-items.component.html',
  styleUrls: ['./cart-items.component.css'],
  providers: [
    CartService,
    LocalStorage,
    PaymentService
  ]
})
export class CartItemsComponent implements OnInit {

  displayedColumns: string[];
  cart: CartModel;
  orderAmount: number;
  paymentCallBack: Predicate<string>;

  constructor(
    private cartService: CartService,
    private dialog: MatDialog,
    private localStorage: LocalStorage,
    private paymentService: PaymentService
    ) {
    this.displayedColumns = DisplayedColumnsConstans.cartItems;
    this.paymentCallBack = this.create.bind(this);
  }

  getCart(): void {
    this.cart = this.localStorage.getCart();
    if (this.cart === null || this.cart.orderItemModel.items.length === 0) {
      this.dialog.closeAll();
    }
    this.orderAmount = 0;
    this.cart.orderItemModel.items.forEach((element: OrderItemModelItem) => {
      this.orderAmount += element.unitPrice * element.count;
    });
  }

  openDialog(orderId: number) {
    this.dialog.closeAll();
    let dialogRef = this.dialog.open(PaymentSuccessComponent, {data: orderId});
  }

  remove(element: OrderItemModelItem): void {
    let index = this.cart.orderItemModel.items.indexOf(element);
    if (index > -1) {
      this.cart.orderItemModel.items.splice(index, 1);
    }
    this.localStorage.setCart(this.cart);
    this.getCart();
  }

  create(transactionId: string) {
    this.cart.userId = this.localStorage.getUser().id;
    this.cart.transactionId = transactionId;
    this.cart.orderAmount = this.orderAmount;
    this.cartService.postData(this.cart).subscribe((data: OrderManagmentModelItem) => {
      this.openDialog(data.id);
    });
    localStorage.removeItem('cart');
  }

  pay() {
    this.paymentService.pay(this.orderAmount, this.paymentCallBack);
  }

  ngOnInit() {
    this.getCart();
    this.paymentService.loadStripe();
  }
}
