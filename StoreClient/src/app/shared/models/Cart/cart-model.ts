import { OrderItemModel } from '../OrderItem/order-item-model';

export class CartModel {
  orderItemModel: OrderItemModel;
  transactionId: string;
  description: string;
  orderAmount: number;
  userId: number;
}
