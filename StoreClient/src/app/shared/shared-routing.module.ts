import { RemoveComponent } from './components/remove/remove.component';
import { Routes } from '@angular/router';
import { ErrorListComponent } from './components/error-list/error-list.component';

export const routes: Routes = [
  {path: 'remove', component: RemoveComponent },
  {path: 'error-list', component: ErrorListComponent }
];
