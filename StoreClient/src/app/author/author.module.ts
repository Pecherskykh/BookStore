import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './author-routing.module';
import { CreateComponent } from './create/create.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { AuthorsComponent } from './authors/authors.component';


@NgModule({
  declarations: [
    CreateComponent,
    RemoveComponent,
    UpdateComponent,
    AuthorsComponent
  ],
  imports: [RouterModule.forChild(routes), CommonModule, ReactiveFormsModule, MaterialModule]
})
export class AuthorModule { }
