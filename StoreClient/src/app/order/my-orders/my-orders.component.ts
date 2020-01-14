import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/shared/services/order-service';
import { OrderManagmentModelItem } from 'src/app/shared/models/Orders/order-managment-model-item';
import { PageEvent, MatSort } from '@angular/material';
import { OrdersFilterModel } from 'src/app/shared/models/Orders/orders-filter-model';
import { OrderSortType } from 'src/app/shared/enums/order-sort-type';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { FormControl } from '@angular/forms';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';
import { PrintingEditionConstants } from 'src/app/shared/constans/printing-edition-constants';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { OrderManagmentModel } from 'src/app/shared/models/Orders/order-managment-model';
import { PaginationConstants } from 'src/app/shared/constans/pagination-constants';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css'],
  providers: [OrderService, LocalStorage]
})
export class MyOrdersComponent implements OnInit {

  pageSizeOptions: number[];
  displayedColumns: string[];
  search: FormControl;
  typePrintingEditionItems: string[];
  count: number;
  pageIndex: number;
  ordersFilterModel: OrdersFilterModel;
  user: UserModelItem;
  items: Array<OrderManagmentModelItem>;

  constructor(private orderService: OrderService, private localStorage: LocalStorage) {
    this.pageSizeOptions = PaginationConstants.pageSizeOptions;
    this.user = this.localStorage.getUser();
    this.ordersFilterModel = new OrdersFilterModel();
    this.ordersFilterModel.sortType = OrderSortType.id;
    this.ordersFilterModel.sortingDirection = SortingDirection.asc;
    this.ordersFilterModel.pageCount = BaseConstants.zero;
    this.ordersFilterModel.pageSize = BaseConstants.ten;
    this.ordersFilterModel.searchString = this.user.userName;
    this.displayedColumns = DisplayedColumnsConstans.myOrders;
    this.typePrintingEditionItems = PrintingEditionConstants.typePrintingEditionItems;
   }

  getOrders(): void {
    this.orderService.getData(this.ordersFilterModel).subscribe((data: OrderManagmentModel) => {
      this.items = data.items;
      this.count = data.count;
  });
}

sortData(event: MatSort): void {
  if (event.active === OrderSortType[OrderSortType.id]) {
    this.ordersFilterModel.sortType = OrderSortType.id;
  }

  if (event.active === OrderSortType[OrderSortType.id]) { //todo use enums
    this.ordersFilterModel.sortType = OrderSortType.date;
  }

  if (event.active === OrderSortType[OrderSortType.orderAmount]) {
    this.ordersFilterModel.sortType = OrderSortType.orderAmount;
  }

  if (event.direction === SortingDirection[SortingDirection.asc]) {
    this.ordersFilterModel.sortingDirection = SortingDirection.asc;
  }

  if (event.direction === SortingDirection[SortingDirection.desc]) {
    this.ordersFilterModel.sortingDirection = SortingDirection.desc;
  }

  this.getOrders();
}

getServerData(event: PageEvent): void {
  this.pageIndex = event.pageIndex;
  this.ordersFilterModel.pageSize = event.pageSize;
  this.ordersFilterModel.pageCount = this.pageIndex;
  this.getOrders();
}

  ngOnInit(): void {
    this.getOrders();
  }
}
