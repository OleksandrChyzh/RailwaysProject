import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyTicketsComponent } from './my-tickets/my-tickets.component';
import { ProfileComponent } from './profile/profile.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

export const routes: Routes = [
  { path: '', component: HomeComponent }, // Головна сторінка
  { path: 'my-tickets', component: MyTicketsComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'schedule', component: ScheduleComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' } // Перенаправлення, якщо шлях невідомий
];
