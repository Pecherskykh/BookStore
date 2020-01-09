import { UserModelItem } from '../models/Users/user-model-item';
import { BehaviorSubject } from 'rxjs';
import { CartModel } from '../models/Cart/cart-model';

export class LocalSorage {
  setUser(user: UserModelItem) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser(): UserModelItem {
    return JSON.parse(localStorage.getItem('user'));
  }

  setCart(cart: CartModel) {
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  getCart(): CartModel {
    return JSON.parse(localStorage.getItem('cart'));
  }
}
