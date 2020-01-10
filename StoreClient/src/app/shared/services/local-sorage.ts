import { UserModelItem } from '../models/Users/user-model-item';
import { BehaviorSubject } from 'rxjs';
import { CartModel } from '../models/Cart/cart-model';
import { OrderItemModelItem } from '../models/OrderItem/order-item-model-item';
import { OrderItemModel } from '../models/OrderItem/order-item-model';

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

    let cartModel: CartModel = new CartModel();
    cartModel.orderItemModel = new OrderItemModel();
    cartModel.orderItemModel.items = new Array<OrderItemModelItem>();
    let localCart: CartModel;
    localCart = JSON.parse(localStorage.getItem('cart'));

    localCart.orderItemModel.items.forEach((element: OrderItemModelItem) => {
      cartModel.orderItemModel.items.push({
        count: parseInt(element.count),
        printingEditionId: parseInt(element.printingEditionId),
        title: element.title.toString(),
        unitPrice: parseFloat(element.unitPrice)
      });
    });

    return cartModel;
  }
}
