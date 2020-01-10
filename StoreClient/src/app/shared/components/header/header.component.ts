import { Component, OnInit } from '@angular/core';
import { AccontService } from '../../services/accont-service';
import { MatDialog } from '@angular/material';
import { CartItemsComponent } from 'src/app/cart/cart-items/cart-items.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [AccontService]
})
export class HeaderComponent implements OnInit {

  constructor(private accontService: AccontService, private dialog: MatDialog) { }

  cart() {
    debugger;
    let dialogRef = this.dialog.open(CartItemsComponent);
  }

  logOut() {
    /*localStorage.removeItem('user');
    localStorage.removeItem('cart');
    this.accontService.logOut();*/
    location.href = 'http://localhost:4200/account/login';
  }

  ngOnInit() {
  }
}
