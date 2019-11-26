import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material';
import { MatTableModule } from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatPaginatorModule,
  MatTableModule
];

@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
