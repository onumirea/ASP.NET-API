import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AutentificareService } from './autentificare.service';
import { TokenStorageService } from '../services/token-storage.service';

const URL1 = 'https://localhost:5001/api/reteta';
const URL2 = 'https://localhost:5001/api/retetaingredient';


@Injectable({
  providedIn: 'root'
})
export class RetetaService {

  constructor(
    private http: HttpClient,
    private autentificareService: AutentificareService, 
    private tokenStorage: TokenStorageService
  ) { }
  private httpOptions = {
    headers: new HttpHeaders({ 
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.tokenStorage.getToken(), 
    })
    
  };
  postReteta(
    nume: string, grad_dificultate: string, 
    durata_minute: number, numar_portii: number, 
    categorie: string, bucatarie:string, 
    mod_preparare: string, autorId: number,
    informatii_nutritionale: any): Observable<any> {
    console.log(this.tokenStorage.getToken());
    return this.http.post(URL1, {
      nume,
      grad_dificultate,
      durata_minute,
      numar_portii,
      categorie,
      bucatarie,
      mod_preparare,
      autorId,
      informatii_nutritionale,
    }, this.httpOptions);
  }
  postIngredientReteta(retetaId: number, ingredientId: number, cantitate: number): Observable<any> {
    return this.http.post(URL2, {
      retetaId,
      ingredientId,
      cantitate,
    }, this.httpOptions);
  }
  public ingredientWithNume(nume_ingred: string){
    return this.http.get(`https://localhost:5001/api/ingredient/byname/${nume_ingred}`);
  }
}
