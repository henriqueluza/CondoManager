import { Routes } from '@angular/router';
import {Auth} from './features/auth/auth';
import {Dashboard} from "./features/dashboard/dashboard";

export const routes: Routes = [
  {path: "auth", component: Auth},
  { path: 'dashboard', component: Dashboard },
  {path: "", redirectTo: "auth", pathMatch: "full"}
];
