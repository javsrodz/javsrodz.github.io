import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Componentes angular-material
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import {MatTableModule} from '@angular/material/table';

//Componentes para formularios
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { LoginComponent } from './Components/login/login.component';
import { ToolbarComponent } from './Components/toolbar/toolbar.component';
import { HomeComponent } from './Components/home/home.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';

import 'bootstrap';
import { ProductosComponent } from './Components/productos/productos.component';
import { ContactoComponent } from './Components/contacto/contacto.component';
import { CarruselComponent } from './Components/carrusel/carrusel.component';
import { NuevousComponent } from './Components/nuevous/nuevous.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ToolbarComponent,
    HomeComponent,
    DashboardComponent,
    ProductosComponent,
    ContactoComponent,
    CarruselComponent,
    NuevousComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    //Componentes angular material
    MatToolbarModule,MatButtonModule,MatIconModule,MatCardModule,MatSidenavModule,MatTableModule,

    //Servicios
    HttpClientModule,

    //Componentes para formularios
    
ReactiveFormsModule,MatFormFieldModule,MatInputModule,MatInputModule,MatMenuModule,FormsModule,MatSelectModule,MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
