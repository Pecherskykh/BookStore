import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatSortModule,
  MatSlideToggleModule
} from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatSortModule,
  MatSlideToggleModule
];

@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
