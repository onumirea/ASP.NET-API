import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AllreteteService {
  private apiUrl = 'https://localhost:5001';
  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService
  ) {}
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.tokenStorage.getToken(), 
    }),
  };
  public AllRetete(url: string) : Observable<any>{
    return this.http.get(url);
  }
  public RetetaWithNume(id: number){
    return this.http.get(`${this.apiUrl}/api/Reteta/ingredienteById/${id}`);
  }
  public RecenziileRetetei(id: number){
    return this.http.get(`${this.apiUrl}/api/recenzie/recenzii/${id}`);
  }
  public RatingMediuReteta(id: number) {
    return this.http.get(`${this.apiUrl}/api/recenzie/rating_mediu/${id}`);
  }
}
