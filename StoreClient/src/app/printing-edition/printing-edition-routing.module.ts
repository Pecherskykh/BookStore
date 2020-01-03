import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { PrintingEditionDialogComponent } from './printing-edition-dialog/printing-edition-dialog.component';
import { HomePageComponent } from './home-page/home-page.component';
import { BookDetailsComponent } from './book-details/book-details.component';

export const routes: Routes = [
  {path: 'printing-edition-management', component: PrintingEditionManagementComponent },
  {path: 'printing-edition-dialog', component: PrintingEditionDialogComponent },
  {path: 'home', component: HomePageComponent },
  {path: 'book-details/:id', component: BookDetailsComponent }
];
