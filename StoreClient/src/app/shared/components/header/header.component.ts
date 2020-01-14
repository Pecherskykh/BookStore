import { Component, OnInit } from '@angular/core';
import { AccontService } from '../../services/accont-service';
import { MatDialog } from '@angular/material';
import { CartItemsComponent } from 'src/app/cart/cart-items/cart-items.component';
import { UserModelItem } from '../../models/Users/user-model-item';
import { LocalStorage } from '../../services/local-storage';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [AccontService, LocalStorage]
})
export class HeaderComponent implements OnInit {

  user: UserModelItem;

  constructor(private accontService: AccontService, private dialog: MatDialog, private localStorage: LocalStorage) {
    this.user = this.localStorage.getUser();
  }

  cart(): void {
    let cart = this.localStorage.getCart();
    if (cart === null || cart.orderItemModel.items.length === 0) {
      return;
    }
    let dialogRef = this.dialog.open(CartItemsComponent);
  }

  logOut() {
    localStorage.removeItem('user');
    localStorage.removeItem('cart');
    this.accontService.logOut().subscribe();
    location.href = 'http://localhost:4200/account/login';
  }

  ngOnInit() {
  }
}
