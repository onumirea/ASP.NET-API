import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MagazineComponent } from './magazine/magazine.component';
import { RegisterComponent } from './register/register.component';
import { AperitiveComponent } from './aperitive/aperitive.component';
import { FeluriPrincipaleComponent } from './feluri-principale/feluri-principale.component';
import { DeserturiComponent } from './deserturi/deserturi.component';
import { CiorbeComponent } from './ciorbe/ciorbe.component';
import { RetetaComponent } from './reteta/reteta.component';
import { ViewRetetaComponent } from './view-reteta/view-reteta.component';
import { IngredienteComponent } from './ingrediente/ingrediente.component';
import { IngredientComponent } from './ingredient/ingredient.component';
import { ViewIngredientComponent } from './view-ingredient/view-ingredient.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ProfilComponent } from './profil/profil.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MagazineComponent,
    RegisterComponent,
    AperitiveComponent,
    FeluriPrincipaleComponent,
    DeserturiComponent,
    CiorbeComponent,
    RetetaComponent,
    ViewRetetaComponent,
    IngredienteComponent,
    IngredientComponent,
    ViewIngredientComponent,
    LoginComponent,
    ProfilComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
