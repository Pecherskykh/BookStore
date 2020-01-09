import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {OrderManagmentModel} from '../models/Orders/order-managment-model';
import { Observable } from 'rxjs';
import { OrdersFilterModel } from '../models/Orders/orders-filter-model';
import { environment } from 'src/environments/environment';

@Injectable()

export class OrderService {

  constructor(private http: HttpClient) { }

  getData(ordersFilterModel: OrdersFilterModel): Observable<OrderManagmentModel> {
    return this.http.post<OrderManagmentModel>(
      `${environment.apiUrl}order/getOrders`, ordersFilterModel);
  }
}
