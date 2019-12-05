import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { CreateComponent } from './create/create.component';
import { RemoveComponent } from './remove/remove.component';

export const routes: Routes = [
  {path: 'printing-edition-management', component: PrintingEditionManagementComponent },
  {path: 'create', component: CreateComponent },
  {path: 'remove', component: RemoveComponent }
];
