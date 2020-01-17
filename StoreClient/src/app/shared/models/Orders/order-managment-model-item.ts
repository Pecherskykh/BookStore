import {OrderItemModelItem} from '../OrderItem/order-item-model-item';
import { BaseModel } from '../Base/base-model';

export class OrderManagmentModelItem extends BaseModel {
  id: number;
  date: Date;
  userName: string;
  userEmail: string;
  orderItems: Array<OrderItemModelItem>;
  orderAmount: number;
}
