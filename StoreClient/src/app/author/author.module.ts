import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './author-routing.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { AuthorsComponent } from './authors/authors.component';
import { SharedModule } from '../shared/shared.module';
import { AuthorDialogComponent } from './author-dialog/author-dialog.component';


@NgModule({
  declarations: [
    AuthorsComponent,
    AuthorDialogComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    CommonModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class AuthorModule { }
