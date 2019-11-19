import { Component, OnInit } from '@angular/core';
import {OrderService} from 'src/app/shared/services/order-service';
import {OrderManagmentModelItem} from 'src/app/shared/models/Orders/order-managment-model-item';

@Component({
  selector: 'app-order-managment',
  templateUrl: './order-managment.component.html',
  styleUrls: ['./order-managment.component.css'],
  providers: [OrderService]
})
export class OrderManagmentComponent implements OnInit {

  constructor(private orderService: OrderService) { }

  items: Array<OrderManagmentModelItem>;

  GetOrders() {
    this.orderService.getData().subscribe(data => {
      this.items = data.items;
  });
}

  ngOnInit() {
  }

}
