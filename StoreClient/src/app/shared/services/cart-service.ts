import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartModel } from '../models/Cart/cart-model';
import { environment } from 'src/environments/environment';
import { OrderItemModel } from '../models/OrderItem/order-item-model';
import { OrderItemModelItem } from '../models/OrderItem/order-item-model-item';
import { Observable } from 'rxjs';
import { OrderManagmentModelItem } from '../models/Orders/order-managment-model-item';

@Injectable()

export class CartService {

  constructor(private http: HttpClient) { }

  postData(cartModel: CartModel): Observable<OrderManagmentModelItem> {
    return this.http.post<OrderManagmentModelItem>(`${environment.apiUrl}order/create`, cartModel, { withCredentials: true });
  }
}
