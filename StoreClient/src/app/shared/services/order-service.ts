import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {OrderManagmentModel} from '../models/Orders/order-managment-model';
import { Observable } from 'rxjs';
import { OrdersFilterModel } from '../models/Orders/orders-filter-model';

@Injectable()

export class OrderService {

  constructor(private http: HttpClient) { }

  getData(ordersFilterModel: OrdersFilterModel): Observable<OrderManagmentModel> {
    return this.http.post<OrderManagmentModel>(
      'https://localhost:44319/api/order/getOrders', ordersFilterModel);
  }
}
