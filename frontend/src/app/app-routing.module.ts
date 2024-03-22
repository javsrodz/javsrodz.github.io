import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { HomeComponent } from './Components/home/home.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { guardaGuard } from './Guardas/guarda.guard';
import { ProductosComponent } from './Components/productos/productos.component';
import { ContactoComponent } from './Components/contacto/contacto.component';
import { NuevousComponent } from './Components/nuevous/nuevous.component';
const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'admin',component:DashboardComponent,canActivate:[guardaGuard]},
  {path:'registrar',component:NuevousComponent},
  {path:'productos',component:ProductosComponent},
  {path:'contacto',component:ContactoComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
