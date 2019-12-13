import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { PrintingEditionDialogComponent } from './printing-edition-dialog/printing-edition-dialog.component';

export const routes: Routes = [
  {path: 'printing-edition-management', component: PrintingEditionManagementComponent },
  {path: 'create', component: CreateComponent },
  {path: 'update', component: UpdateComponent },
  {path: 'printing-edition-dialog', component: PrintingEditionDialogComponent }
];
