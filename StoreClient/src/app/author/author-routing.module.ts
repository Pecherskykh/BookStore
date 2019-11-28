import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateComponent } from './create/create.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { AuthorsComponent } from './authors/authors.component';


export const routes: Routes = [
  { path: 'create', component: CreateComponent },
  { path: 'authors', component: AuthorsComponent },
  { path: 'remove', component: RemoveComponent },
  { path: 'update', component: UpdateComponent },
];
