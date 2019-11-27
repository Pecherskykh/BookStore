import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material';
import { MatTableModule } from '@angular/material';
import { MatDialogModule } from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule
];

@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
