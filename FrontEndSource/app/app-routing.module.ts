import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RetetaComponent } from './reteta/reteta.component';
import { HomeComponent } from './home/home.component';
import { MagazineComponent } from './magazine/magazine.component';
import { RegisterComponent } from './register/register.component';
import { AperitiveComponent } from './aperitive/aperitive.component';
import { FeluriPrincipaleComponent } from './feluri-principale/feluri-principale.component';
import { DeserturiComponent } from './deserturi/deserturi.component';
import { CiorbeComponent } from './ciorbe/ciorbe.component';
import { ViewRetetaComponent } from './view-reteta/view-reteta.component';
import { IngredienteComponent } from './ingrediente/ingrediente.component';
import { IngredientComponent } from './ingredient/ingredient.component';
import { ViewIngredientComponent } from './view-ingredient/view-ingredient.component';
import { LoginComponent } from './login/login.component';
import { ProfilComponent } from './profil/profil.component';
import { AuthGuard } from './helpers/auth.guard';

const routes: Routes = [
  {path: '', redirectTo:'/home', pathMatch: 'full'},
  {path: 'retete', component:RetetaComponent}, 
  {path: 'home', component: HomeComponent},
  {path: 'magazine', component: MagazineComponent, canActivate: [AuthGuard]},
  {path: 'register', component: RegisterComponent},
  {path: 'aperitive', component: AperitiveComponent},
  {path: 'feluri-principale', component: FeluriPrincipaleComponent},
  {path: 'deserturi', component: DeserturiComponent},
  {path: 'ciorbe', component: CiorbeComponent},
  {path: 'view-reteta/:id', component: ViewRetetaComponent, canActivate: [AuthGuard]},
  {path: 'ingrediente', component: IngredienteComponent, canActivate: [AuthGuard]},
  {path: 'ingredient', component: IngredientComponent, canActivate: [AuthGuard]},
  {path: 'view-ingredient/:nume', component: ViewIngredientComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'profil', component: ProfilComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
