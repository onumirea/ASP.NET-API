import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AutentificareService } from './autentificare.service';
import { TokenStorageService } from '../services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AllIngredienteService {
  private apiUrl = 'https://localhost:5001';
  constructor(
    private http: HttpClient,
    private autentificareService: AutentificareService, 
    private tokenStorage: TokenStorageService
  ) {}
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.tokenStorage.getToken(), 
    }),
  };
  postIngredient(nume: string, unitate_Masura: string, categorie: string): Observable<any> {
    return this.http.post(this.apiUrl + '/api/ingredient', {
      nume,
      unitate_Masura,
      categorie,
    }, this.httpOptions);
  }

  public AllIngrediente(url: string) : Observable<any>{
    console.log('in service');
    return this.http.get(url);
  }
  public IngredWithName(nume: string){
    return this.http.get(`${this.apiUrl}/api/Ingredient/byNameWithMagazine/${nume}`);
  }


}
