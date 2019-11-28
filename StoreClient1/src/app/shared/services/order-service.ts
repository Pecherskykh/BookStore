import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {OrderManagmentModel} from '../models/Orders/order-managment-model';
import { Observable } from 'rxjs';

@Injectable()

export class OrderService {

  constructor(private http: HttpClient) { }

  getData(): Observable<OrderManagmentModel> {
    return this.http.post<OrderManagmentModel>(
      'https://localhost:44319/api/order/getOrders',
      {
        sortType: 3,
        orderStatus: 2,
        sortingDirection: 2,
        searchString: null,
        pageCount: 1,
        pageSize: 10
      }
    );
  }
}