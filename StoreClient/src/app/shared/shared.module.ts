import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './shared-routing.module';
import { RemoveComponent } from './components/remove/remove.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { ErrorListComponent } from './components/error-list/error-list.component';


@NgModule({
  declarations: [RemoveComponent, ErrorListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MaterialModule
  ]
})
export class SharedModule { }
