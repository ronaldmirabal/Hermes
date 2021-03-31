import { DialogDeleteComponent } from './common/delete/dialogdelete.component';
import { DialogCategoriaComponent } from './categoria/dialog/dialogcategoria.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatSidenavModule} from '@angular/material/sidenav';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { from } from 'rxjs';
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
import {FormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './security/jwt.interceptor';

export function tokenGetter(){
  return localStorage.getItem("User");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SidenavComponent,
    CategoriaComponent,
    DialogCategoriaComponent,
    DialogDeleteComponent,
    LoginComponent
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
    MatFormFieldModule
  ],
  providers: [
    [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
