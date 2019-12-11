import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './shared-routing.module';
import { FooterComponent } from './components/footer/footer.component';
import { RemoveComponent } from './components/remove/remove.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';


@NgModule({
  declarations: [FooterComponent, RemoveComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MaterialModule
  ]
})
export class SharedModule { }
