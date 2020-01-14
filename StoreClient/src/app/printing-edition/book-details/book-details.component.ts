import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Subscription } from 'rxjs';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { FormControl } from '@angular/forms';
import { CartModel } from 'src/app/shared/models/Cart/cart-model';
import { OrderItemModelItem } from 'src/app/shared/models/OrderItem/order-item-model-item';
import { LocalStorage } from 'src/app/shared/services/local-storage';
import { OrderItemModel } from 'src/app/shared/models/OrderItem/order-item-model';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css'],
  providers: [PrintingEditionService, LocalStorage]
})
export class BookDetailsComponent implements OnInit {

  cart: CartModel;
  o: OrderItemModelItem;

  currentBookId: number;
  quantity: FormControl;
  printingEdition: PrintingEditionModelItem;
  subscription: Subscription;

  constructor(private activateRoute: ActivatedRoute,
              private printingEditionService: PrintingEditionService,
              private localStorage: LocalStorage) {

    this.quantity = new FormControl(1);
    this.subscription = activateRoute.params.
    subscribe((params: number) => this.currentBookId = params['id']);
  }

  findById() {
    this.printingEditionService.findById(this.currentBookId).subscribe((data: PrintingEditionModelItem) => {
      this.printingEdition = data;
    });
  }

  add() {
    debugger;

    this.cart = this.localStorage.getCart();
    if (this.cart === null) {
      this.cart = new CartModel();
      this.cart.orderItemModel = new OrderItemModel();
      this.cart.orderItemModel.items = new Array<OrderItemModelItem>();
    }

    this.o = new OrderItemModelItem();
    this.o.count = this.quantity.value;
    this.o.printingEditionId = this.currentBookId;
    this.o.title = this.printingEdition.title;
    this.o.unitPrice = this.printingEdition.price;

    this.cart.orderItemModel.items.push(this.o);

    this.localStorage.setCart(this.cart);
  }

  ngOnInit() {
    this.findById();
  }
}
