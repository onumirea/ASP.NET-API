import { Component, OnInit } from '@angular/core';
import { MagazinService } from '../services/magazin.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-magazine',
  templateUrl: './magazine.component.html',
  styleUrls: ['./magazine.component.scss']
})
export class MagazineComponent implements OnInit {

  form: any = {
    nume: null,
    telefon: null,
    email: null,
    site: null,

    judet: null,
    oras: null,
    strada: null,
    numar: null,
    cod_Postal: null
  };
  adresa: any={
    judet: null,
    oras: null,
    strada: null,
    numar: null,
    cod_Postal: null
  }
  isSuccessful = false;
  isFailedMagazin = false;
  errorMessage = '';
  subscription = new Subscription();
  listaMagazine:any = [];
  url='https://localhost:5001/api/magazin/all';
  constructor(
    private MS: MagazinService) { }

  ngOnInit(): void {
    this.AllMagazineWithAdresa(this.url);
  }

  onSubmit(): void {
    this.adresa.judet = this.form.judet;
    this.adresa.oras = this.form.oras;
    this.adresa.strada = this.form.strada;
    this.adresa.numar = this.form.numar;
    this.adresa.cod_Postal = this.form.cod_Postal;
    this.MS.postMagazin(
      this.form.nume,this.form.telefon,
      this.form.email,this.form.site,
      this.adresa).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isFailedMagazin = false;
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isFailedMagazin = true;
      }
    });
  }

  public AllMagazineWithAdresa(url: string){
    this.subscription.add(
      this.MS.AllMagazineWithAdresa(url)
      .subscribe(res=>{
        console.log(res)
        this.listaMagazine = res;
      },)
    );
  }

  
}
