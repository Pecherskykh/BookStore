import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartModel } from '../models/Cart/cart-model';
import { environment } from 'src/environments/environment';

@Injectable()

export class CartService {

  constructor(private http: HttpClient) { }

  /*postData(cartModel: CartModel) {
      return this.http.post(`${environment.apiUrl}order/create`, cartModel, { withCredentials: true });
  }*/

  /*export class CartModel {
    orderItemModel: OrderItemModel;
    transactionId: number;
    description: string;
    orderAmount: number;
    userId: number;
  }*/

  /*count: number;
    orderId: number;
    printingEditionId: number;
    unitPrice: number;
    type: TypePrintingEdition;
    title: string;*/

  /*postData(cartModel: CartModel) {
    return this.http.post(`${environment.apiUrl}order/create`, {
      orderItemModel: {
        items: [
          {
            count: 1000,
            orderId: 0,
            printingEditionId: 13,
            title: 'New TitleUpdate Edit',
            unitPrice: 1000
          }]},
      transactionId: 10,
      description: 'string',
      orderAmount: 14,
      userId: 0
    }, { withCredentials: true });
}*/
  postData(cartModel: CartModel) {
    let c = new CartModel();
    c.orderItemModel.items = cartModel.orderItemModel.items;
    return this.http.post(`${environment.apiUrl}order/create`, c, { withCredentials: true });
  }
}
