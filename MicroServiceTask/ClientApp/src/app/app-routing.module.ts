import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './Helpers/auth.guard';
import { LoginComponent } from './login/login.component';
import { TaskComponent } from './task/task.component';

const routes: Routes = [{
  path: '', component: DashboardComponent, canActivate: [AuthGuard], children: [{ path: 'task', component: TaskComponent }]
},
  { path: 'login', component: LoginComponent },

  

  { path: '', redirectTo: 'PagenotfoundComponent', pathMatch: 'full' },
 // { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
