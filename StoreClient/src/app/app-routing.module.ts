import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
  {path: 'author', loadChildren: () => import('./author/author.module').then(m => m.AuthorModule) },
  {path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule) },
  {path: 'order', loadChildren: () => import('./order/order.module').then(m => m.OrderModule) },
  {path: 'printing-edition', loadChildren: () => import('./printing-edition/printing-edition.module').then(m => m.PrintingEditionModule) },
  {path: 'shared', loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule) },
  {path: 'cart', loadChildren: () => import('./cart/cart.module').then(m => m.CartModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
