import { Predicate } from '@angular/core';

export class PaymentService {

  pay(orderAmount: number, callback: Predicate<string>) {
    let handler = (window as any).StripeCheckout.configure({
      key: 'pk_test_gf7mf4fFzhjfNE3ODXqeuFOM00fzYutuj3',
      locale: 'auto',
      token(token: any) {
        callback(token.id);
      }
    });

    handler.open({
      name: 'Demo Site',
      description: '2 widgets',
      amount: orderAmount * 100
    });
  }

  loadStripe() {
    if (!window.document.getElementById('stripe-script')) {
      let stripe = window.document.createElement('script');
      stripe.id = 'stripe-script';
      stripe.type = 'text/javascript';
      stripe.src = 'https://checkout.stripe.com/checkout.js';
      window.document.body.appendChild(stripe);
    }
  }
}
