import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routes } from './printing-edition-routing.module';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PrintingEditionManagementComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ]
})
export class PrintingEditionModule { }
