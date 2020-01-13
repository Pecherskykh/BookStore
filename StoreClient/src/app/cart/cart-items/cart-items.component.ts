import { Component, OnInit } from '@angular/core';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';
import { OrderItemModelItem } from 'src/app/shared/models/OrderItem/order-item-model-item';
import { LocalSorage } from 'src/app/shared/services/local-sorage';
import { CartModel } from 'src/app/shared/models/Cart/cart-model';
import { CartService } from 'src/app/shared/services/cart-service';

@Component({
  selector: 'app-cart-items',
  templateUrl: './cart-items.component.html',
  styleUrls: ['./cart-items.component.css'],
  providers: [CartService, LocalSorage]
})
export class CartItemsComponent implements OnInit {

  displayedColumns: string[];
  cart: CartModel;
  orderAmount: number;

  constructor(private cartService: CartService, private localStorage: LocalSorage) {
    this.displayedColumns = DisplayedColumnsConstans.cartItems;
    this.orderAmount = 0;
  }

  getCart(): void {
    debugger;
    this.cart = this.localStorage.getCart();

    this.cart.orderItemModel.items.forEach((element: OrderItemModelItem) => {
      this.orderAmount += element.unitPrice * element.count;
    });
  }

  remove(element: OrderItemModelItem): void {
    let index = this.cart.orderItemModel.items.indexOf(element);
    if (index > -1) {
      this.cart.orderItemModel.items.splice(index, 1);
    }
    this.localStorage.setCart(this.cart);
    this.getCart();
  }

  create() {
    debugger;
    this.cart.userId = 54;
    this.cart.orderAmount = this.orderAmount;
    this.cartService.postData(this.cart).subscribe();
    localStorage.removeItem('cart');
  }


  pay() {
    let handler = (window as any).StripeCheckout.configure({
      key: 'pk_test_aeUUjYYcx4XNfKVW60pmHTtI',
      locale: 'auto',
      token(token: any) {

        console.log(token);
        alert('Token Created!!');
      }
    });

    handler.open({
      name: 'Demo Site',
      description: '2 widgets',
      amount: this.orderAmount * 100
    });
  }

  loadStripe() {
    if (!window.document.getElementById('stripe-script')) {
      let s = window.document.createElement('script');
      s.id = 'stripe-script';
      s.type = 'text/javascript';
      s.src = 'https://checkout.stripe.com/checkout.js';
      window.document.body.appendChild(s);
    }
}

  ngOnInit() {
    this.getCart();
    this.loadStripe();
  }
}
