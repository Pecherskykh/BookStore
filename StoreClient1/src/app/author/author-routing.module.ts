import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateComponent } from './create/create.component';
import { FindComponent } from './find/find.component';
import { GetAuthorsComponent } from './get-authors/get-authors.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';


export const routes: Routes = [
  { path: 'create', component: CreateComponent },
  { path: 'find', component: FindComponent },
  { path: 'get-authors', component: GetAuthorsComponent },
  { path: 'remove', component: RemoveComponent },
  { path: 'update', component: UpdateComponent },
];
