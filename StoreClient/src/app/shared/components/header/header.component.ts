import { Component, OnInit } from '@angular/core';
import { AccontService } from '../../services/accont-service';
import { MatDialog } from '@angular/material';
import { CartItemsComponent } from 'src/app/cart/cart-items/cart-items.component';
import { UserModelItem } from '../../models/Users/user-model-item';
import { LocalSorage } from '../../services/local-sorage';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [AccontService, LocalSorage]
})
export class HeaderComponent implements OnInit {

  user: UserModelItem;

  constructor(private accontService: AccontService, private dialog: MatDialog, private localStorage: LocalSorage) {
    this.user = this.localStorage.getUser();
  }

  cart() {
    debugger;
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
