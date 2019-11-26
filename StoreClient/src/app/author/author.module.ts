import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './author-routing.module';
import { CreateComponent } from './create/create.component';
import { FindComponent } from './find/find.component';
import { GetAuthorsComponent } from './get-authors/get-authors.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';


@NgModule({
  declarations: [CreateComponent, FindComponent, GetAuthorsComponent, RemoveComponent, UpdateComponent, GetAuthorsComponent],
  imports: [RouterModule.forChild(routes), CommonModule, ReactiveFormsModule, MaterialModule]
})
export class AuthorModule { }
