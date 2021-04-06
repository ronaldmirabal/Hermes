import { AddFacturaComponent } from './factura/addfactura.component';
import { DialogArticuloComponent } from './articulo/dialog/dialogArticulo.component';
import { ArticuloComponent } from './articulo/articulo.component';
import { DialogClienteComponent } from './cliente/dialog/dialogCliente.component';
import { DialogDeleteComponent } from './common/delete/dialogdelete.component';
import { DialogCategoriaComponent } from './categoria/dialog/dialogcategoria.component';
import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import {MatSidenavModule} from '@angular/material/sidenav';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import {MatIconModule} from '@angular/material/icon'
import {MatListModule} from '@angular/material/list';
import {SidenavComponent } from './components/sidenav/sidenav.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {CategoriaComponent } from './categoria/categoria.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './security/jwt.interceptor';
import { ClienteComponent } from './cliente/cliente.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatExpansionModule} from '@angular/material/expansion';
import { FacturaComponent } from './factura/factura.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SidenavComponent,
    CategoriaComponent,
    DialogCategoriaComponent,
    DialogClienteComponent,
    DialogDeleteComponent,
    DialogArticuloComponent,
    LoginComponent,
    ClienteComponent,
    ArticuloComponent,
    FacturaComponent,
    AddFacturaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatToolbarModule,
    HttpClientModule,
    MatTableModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    MatSelectModule,
    MatGridListModule,
    MatExpansionModule
  ],
  providers: [
    Title,
    [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
