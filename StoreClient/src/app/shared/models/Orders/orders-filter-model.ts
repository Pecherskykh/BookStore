import {BaseFilterModel} from '../Base/base-filter-model';
import { OrderSortType } from '../../enums/order-sort-type';

export class OrdersFilterModel extends BaseFilterModel {
  sortType: OrderSortType;
}
