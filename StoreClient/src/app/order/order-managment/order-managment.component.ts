import { Component, OnInit } from '@angular/core';
import {OrderService} from 'src/app/shared/services/order-service';
import {OrderManagmentModelItem} from 'src/app/shared/models/Orders/order-managment-model-item';
import { PageEvent, MatSort } from '@angular/material';
import { OrdersFilterModel } from 'src/app/shared/models/Orders/orders-filter-model';
import { OrderSortType } from 'src/app/shared/enums/order-sort-type';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { FormControl } from '@angular/forms';
import { debug } from 'util';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';

@Component({
  selector: 'app-order-managment',
  templateUrl: './order-managment.component.html',
  styleUrls: ['./order-managment.component.css'],
  providers: [OrderService]
})
export class OrderManagmentComponent implements OnInit {
  displayedColumns: string[];
  search: FormControl;
  typePrintingEditionItems: string[];
  count: number;
  pageIndex: number;
  ordersFilterModel: OrdersFilterModel;
  items: Array<OrderManagmentModelItem>;

  constructor(private orderService: OrderService) {
    this.ordersFilterModel = new OrdersFilterModel();
    this.ordersFilterModel.sortType = OrderSortType.Id;
    this.ordersFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.ordersFilterModel.pageCount = 0;
    this.ordersFilterModel.pageSize = 10;
    this.search = new FormControl('');
    this.displayedColumns = DisplayedColumnsConstans.orders;
    this.typePrintingEditionItems = ['book', 'magazine', 'newspaper'];
   }

  ngOnInit() {
    this.GetOrders();
  }

  GetOrders() {
    this.orderService.getData(this.ordersFilterModel).subscribe(data => {
      this.items = data.items;
      this.count = data.count;
  });
}

filterOrders() {

  this.pageIndex = 0;

  this.ordersFilterModel.pageCount = 0;
  this.ordersFilterModel.searchString = this.search.value;

  this.GetOrders();
}

sortData(event: MatSort) {
  if (event.active === 'id') {
    this.ordersFilterModel.sortType = OrderSortType.Id;
  }

  if (event.active === 'date') { //todo use enums
    this.ordersFilterModel.sortType = OrderSortType.Date;
  }

  if (event.active === 'userName') {
    this.ordersFilterModel.sortType = OrderSortType.UserName;
  }

  if (event.active === 'userEmail') {
    this.ordersFilterModel.sortType = OrderSortType.UserEmail;
  }

  if (event.active === 'orderAmount') {
    this.ordersFilterModel.sortType = OrderSortType.OrderAmount;
  }

  if (event.direction === 'asc') {
    this.ordersFilterModel.sortingDirection = SortingDirection.lowToHigh;
  }

  if (event.direction === 'desc') {
    this.ordersFilterModel.sortingDirection = SortingDirection.highToLow;
  }

  this.GetOrders();
}

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.ordersFilterModel.pageSize = event.pageSize;
    this.ordersFilterModel.pageCount = this.pageIndex;
    this.GetOrders();
  }
}
