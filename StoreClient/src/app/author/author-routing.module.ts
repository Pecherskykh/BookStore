import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsComponent } from './authors/authors.component';
import { AuthorDialogComponent } from './author-dialog/author-dialog.component';


export const routes: Routes = [
  { path: 'authors', component: AuthorsComponent },
  { path: 'author-dialog', component: AuthorDialogComponent }
];
