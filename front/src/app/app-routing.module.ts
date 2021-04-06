import { FacturaComponent } from './factura/factura.component';
import { ArticuloComponent } from './articulo/articulo.component';
import { ClienteComponent } from './cliente/cliente.component';
import { CategoriaComponent } from './categoria/categoria.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AuthGuard } from './security/auth.guard';
import { LoginComponent } from './login/login.component';
import { AddFacturaComponent } from './factura/addfactura.component';

const routes: Routes = [
  {path: '', redirectTo:'/home', pathMatch: 'full'},
  {path: 'home',component:HomeComponent, canActivate: [AuthGuard]},
  {path: 'categoria',component:CategoriaComponent,canActivate: [AuthGuard]},
  {path: 'cliente',component:ClienteComponent,canActivate: [AuthGuard]},
  {path: 'articulo',component:ArticuloComponent,canActivate: [AuthGuard]},
  {path: 'factura',component:FacturaComponent,canActivate: [AuthGuard]},
  {path: 'addfactura',component:AddFacturaComponent,canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
