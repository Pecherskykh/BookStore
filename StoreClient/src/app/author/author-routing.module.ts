import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { AuthorsComponent } from './authors/authors.component';
import { AuthorDialogComponent } from './author-dialog/author-dialog.component';


export const routes: Routes = [
  { path: 'create', component: CreateComponent },
  { path: 'authors', component: AuthorsComponent },
  { path: 'update', component: UpdateComponent },
  { path: 'author-dialog', component: AuthorDialogComponent }
];
