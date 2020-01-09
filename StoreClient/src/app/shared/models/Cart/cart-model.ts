import { OrderItemModel } from '../OrderItem/order-item-model';

export class CartModel {
  orderItemModel: OrderItemModel;
  transactionId: number;
  description: string;
  orderAmount: number;
  userId: number;
}
