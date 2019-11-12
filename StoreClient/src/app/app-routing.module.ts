import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
  {path: 'author', loadChildren: () => import('./author/author.module').then(m => m.AuthorModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
