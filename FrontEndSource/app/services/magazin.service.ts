import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AutentificareService } from './autentificare.service';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class MagazinService {
  private apiUrl = 'https://localhost:5001';
  constructor(
    private http: HttpClient,
    private autentificareService: AutentificareService,
    private tokenStorage:TokenStorageService,
  ) { }
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.tokenStorage.getToken(),
    }),
  };
  public AllMagazineWithAdresa(url: string) : Observable<any>{
    console.log('in service');
    return this.http.get(url);
  }
  postMagazin(
    nume: string, telefon: string, 
    email: string, site: string, 
    adresa: any): Observable<any> {
    return this.http.post(this.apiUrl + "/api/magazin", {
      nume,
      telefon,
      email,
      site,
      adresa,
    }, this.httpOptions);
  }
}
