import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AllreteteService } from '../services/allretete.service';
import { RetetaService } from '../services/reteta.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  form: any = {
    nume: null,
    grad_dificultate: null,
    durata_minute: null,
    numar_portii: null,
    categorie: null,
    bucatarie: null,
    mod_preparare: null,
    autorId: null,
    autor: null,

    calorii: null,
    glucide: null,
    proteine: null,
    grasimi: null
  };
  informatii_nutr: any={
    calorii: null,
    glucide: null,
    proteine: null,
    grasimi: null
  }
  isSuccessful = false;
  isFailedRecenzie = false;
  errorMessage = '';
  subscription = new Subscription();
  listaRetete: any = [];

  url='https://localhost:5001/api/reteta/all';

  constructor(
    private allRS: AllreteteService,
    private RS: RetetaService) { }

  ngOnInit(): void {
    this.AllRetete(this.url);
  }

  onSubmit(): void {
    this.informatii_nutr.calorii = this.form.calorii;
    this.informatii_nutr.glucide = this.form.glucide;
    this.informatii_nutr.proteine = this.form.proteine;
    this.informatii_nutr.grasimi = this.form.grasimi;
    this.RS.postReteta(
      this.form.nume,this.form.grad_dificultate,
      this.form.durata_minute,this.form.numar_portii,
      this.form.categorie,this.form.bucatarie,
      this.form.mod_preparare,this.form.autorId,
      this.informatii_nutr).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isFailedRecenzie = false;
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isFailedRecenzie = true;
      }
    });
  }

  public AllRetete(url: string){
    this.subscription.add(
      this.allRS.AllRetete(url)
      .subscribe(res=>{
        console.log(res[0].reteta)
        this.listaRetete = res;
      },)
    );
  }
}
