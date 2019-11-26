import {OrderItemModelItem} from '../OrderItem/order-item-model-item';

export class OrderManagmentModelItem {
  id: number;
  date: Date;
  userName: string;
  userEmail: string;
  orderItems: Array<OrderItemModelItem>;
  orderAmount: number;
}
