// import { Routes } from '@angular/router';
// import { HomeComponent } from './home/home.component';
// import { MyTicketsComponent } from './my-tickets/my-tickets.component';
// import { ScheduleComponent } from './schedule/schedule.component';
// import { ProfileComponent } from './profile/profile.component';

// export const appRoutes: Routes = [
//   { path: '', component: HomeComponent }, // Головна сторінка
//   { path: 'my-tickets', component: MyTicketsComponent }, // Сторінка "Мої квитки"
//   { path: 'schedule', component: ScheduleComponent }, // Сторінка "Табло"
//   { path: 'profile', component: ProfileComponent }, // Сторінка "Профіль"
//   { path: '**', redirectTo: '' }, // Перенаправлення для невідомих маршрутів
// ];

import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyTicketsComponent } from './my-tickets/my-tickets.component';
import { ProfileComponent } from './profile/profile.component';
import { ScheduleComponent } from './schedule/schedule.component';

export const routes: Routes = [
  { path: '', component: HomeComponent }, // Головна сторінка
  { path: 'my-tickets', component: MyTicketsComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'schedule', component: ScheduleComponent },
  { path: '**', redirectTo: '' } // Перенаправлення, якщо шлях невідомий
];
