import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { routes } from './printing-edition-routing.module';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateComponent } from './create/create.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [PrintingEditionManagementComponent, CreateComponent, RemoveComponent, UpdateComponent],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class PrintingEditionModule { }
