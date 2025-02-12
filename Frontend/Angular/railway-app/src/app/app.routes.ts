import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },  // Головна сторінка
  { path: '**', redirectTo: '' },  // Перенаправлення для невідомих маршрутів
];

