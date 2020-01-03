import { Component, OnInit } from '@angular/core';
import {OrderService} from 'src/app/shared/services/order-service';
import {OrderManagmentModelItem} from 'src/app/shared/models/Orders/order-managment-model-item';
import { PageEvent, MatSort } from '@angular/material';
import { OrdersFilterModel } from 'src/app/shared/models/Orders/orders-filter-model';
import { OrderSortType } from 'src/app/shared/enums/order-sort-type';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { FormControl } from '@angular/forms';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalSorage } from 'src/app/shared/services/local-sorage';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css'],
  providers: [OrderService, LocalSorage]
})
export class MyOrdersComponent implements OnInit {

  displayedColumns: string[];
  search: FormControl;
  typePrintingEditionItems: string[];
  count: number;
  pageIndex: number;
  ordersFilterModel: OrdersFilterModel;
  user: UserModelItem;

  constructor(private orderService: OrderService, private localStorage: LocalSorage) {
    this.user = new UserModelItem();
    this.ordersFilterModel = new OrdersFilterModel();
    this.ordersFilterModel.sortType = OrderSortType.Id;
    this.ordersFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.ordersFilterModel.pageCount = 0;
    this.ordersFilterModel.pageSize = 10;
    this.search = new FormControl('');
    this.displayedColumns = DisplayedColumnsConstans.myOrders;
    this.typePrintingEditionItems = ['book', 'magazine', 'newspaper'];
   }

  items: Array<OrderManagmentModelItem>;

  GetOrders() {
    debugger;
    this.orderService.getData(this.ordersFilterModel).subscribe(data => {
      this.items = data.items;
      this.count = data.count;
  });
}

sortData(event: MatSort) {
  if (event.active === 'id') {
    this.ordersFilterModel.sortType = OrderSortType.Id;
  }

  if (event.active === 'date') { //todo use enums
    this.ordersFilterModel.sortType = OrderSortType.Date;
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

  ngOnInit() {
    this.pageIndex = 0;
    this.user = this.localStorage.getUser();
    this.ordersFilterModel.searchString = this.user.userName;
    this.ordersFilterModel.pageCount = 0;
    this.GetOrders();
  }
}
