import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AutentificareService } from './autentificare.service';
import { TokenStorageService } from '../services/token-storage.service';

const AUTH_API = 'https://localhost:5001/api/recenzie';


@Injectable({
  providedIn: 'root'
})
export class RecenzieService {

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
  postRecenzie(continut: string, rating: number, retetaId: number): Observable<any> {
    console.log(this.tokenStorage.getToken());
    return this.http.post(AUTH_API, {
      continut,
      rating,
      retetaId,
    }, this.httpOptions);
  }

}
