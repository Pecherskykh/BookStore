import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartModel } from '../models/Cart/cart-model';
import { environment } from 'src/environments/environment';
import { OrderItemModel } from '../models/OrderItem/order-item-model';
import { OrderItemModelItem } from '../models/OrderItem/order-item-model-item';
import { Observable } from 'rxjs';

@Injectable()

export class CartService {

  constructor(private http: HttpClient) { }

  postData(cartModel: CartModel) {
    return this.http.post(`${environment.apiUrl}order/create`, cartModel, { withCredentials: true });
  }
}
