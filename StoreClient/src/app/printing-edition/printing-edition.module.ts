import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { routes } from './printing-edition-routing.module';
import { PrintingEditionManagementComponent } from './printing-edition-management/printing-edition-management.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { PrintingEditionDialogComponent } from './printing-edition-dialog/printing-edition-dialog.component';

@NgModule({
  declarations: [PrintingEditionManagementComponent, PrintingEditionDialogComponent],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class PrintingEditionModule { }
