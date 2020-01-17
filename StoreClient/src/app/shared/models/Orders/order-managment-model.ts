import { OrderManagmentModelItem } from './order-managment-model-item';
import { BaseModel } from '../Base/base-model';

export class OrderManagmentModel extends BaseModel {
  count: number;
  items: Array<OrderManagmentModelItem>;
}
