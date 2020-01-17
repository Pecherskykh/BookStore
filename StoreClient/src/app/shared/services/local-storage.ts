import { UserModelItem } from '../models/Users/user-model-item';
import { BehaviorSubject } from 'rxjs';
import { CartModel } from '../models/Cart/cart-model';
import { OrderItemModelItem } from '../models/OrderItem/order-item-model-item';
import { OrderItemModel } from '../models/OrderItem/order-item-model';

export class LocalStorage {
  setUser(user: UserModelItem): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser(): UserModelItem {
    return JSON.parse(localStorage.getItem('user'));
  }

  setCart(cart: CartModel): void {
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  getCart(): CartModel {

    let localCart: CartModel;
    localCart = JSON.parse(localStorage.getItem('cart'));
    if (localCart === null) {
      return null;
    }

    let cartModel: CartModel = new CartModel();
    cartModel.orderItemModel = new OrderItemModel();
    cartModel.orderItemModel.items = new Array<OrderItemModelItem>();

    localCart.orderItemModel.items.forEach((element: OrderItemModelItem) => {
      cartModel.orderItemModel.items.push({
        // tslint:disable-next-line: radix
        count: parseInt(element.count.toString()),
        // tslint:disable-next-line: radix
        printingEditionId: parseInt(element.printingEditionId.toString()),
        title: element.title.toString(),
        unitPrice: parseFloat(element.unitPrice.toString())
      });
    });

    return cartModel;
  }
}
