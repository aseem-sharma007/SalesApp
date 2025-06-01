// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalesRepsComponent } from './components/sales-reps/sales-reps.component';

export const routes: Routes = [
  { path: '', component: SalesRepsComponent } // 👈 default root path
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
