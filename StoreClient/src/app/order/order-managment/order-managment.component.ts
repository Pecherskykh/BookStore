import { Component, OnInit } from '@angular/core';
import {OrderService} from 'src/app/shared/services/order-service';
import {OrderManagmentModelItem} from 'src/app/shared/models/Orders/order-managment-model-item';
import { PageEvent, MatSort } from '@angular/material';
import { OrdersFilterModel } from 'src/app/shared/models/Orders/orders-filter-model';
import { OrderSortType } from 'src/app/shared/enums/order-sort-type';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { FormControl } from '@angular/forms';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';
import { PrintingEditionConstants } from 'src/app/shared/constans/printing-edition-constants';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { OrderManagmentModel } from 'src/app/shared/models/Orders/order-managment-model';
import { PaginationConstants } from 'src/app/shared/constans/pagination-constants';

@Component({
  selector: 'app-order-managment',
  templateUrl: './order-managment.component.html',
  styleUrls: ['./order-managment.component.css'],
  providers: [OrderService]
})
export class OrderManagmentComponent implements OnInit {
  pageSizeOptions: number[];
  displayedColumns: string[];
  search: FormControl;
  typePrintingEditionItems: string[];
  count: number;
  pageIndex: number;
  ordersFilterModel: OrdersFilterModel;
  items: Array<OrderManagmentModelItem>;

  constructor(private orderService: OrderService) {
    this.pageSizeOptions = PaginationConstants.pageSizeOptions;
    this.ordersFilterModel = new OrdersFilterModel();
    this.ordersFilterModel.sortType = OrderSortType.id;
    this.ordersFilterModel.sortingDirection = SortingDirection.asc;
    this.ordersFilterModel.pageCount = BaseConstants.zero;
    this.ordersFilterModel.pageSize = BaseConstants.ten;
    this.search = new FormControl(BaseConstants.stringEmpty);
    this.displayedColumns = DisplayedColumnsConstans.orders;
    this.typePrintingEditionItems = PrintingEditionConstants.typePrintingEditionItems;
   }

  ngOnInit() {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getData(this.ordersFilterModel).subscribe((data: OrderManagmentModel) => {
      this.items = data.items;
      this.count = data.count;
  });
}

filterOrders(): void {

  this.pageIndex = 0;

  this.ordersFilterModel.pageCount = 0;
  this.ordersFilterModel.searchString = this.search.value;

  this.getOrders();
}

sortData(event: MatSort): void {
  if (event.active === OrderSortType[OrderSortType.id]) {
    this.ordersFilterModel.sortType = OrderSortType.id;
  }

  if (event.active === OrderSortType[OrderSortType.date]) {
    this.ordersFilterModel.sortType = OrderSortType.date;
  }

  if (event.active === OrderSortType[OrderSortType.userName]) {
    this.ordersFilterModel.sortType = OrderSortType.userName;
  }

  if (event.active === OrderSortType[OrderSortType.userEmail]) {
    this.ordersFilterModel.sortType = OrderSortType.userEmail;
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
}
