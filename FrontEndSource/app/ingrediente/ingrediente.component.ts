import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AllIngredienteService} from '../services/allingrediente.service';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-ingrediente',
  templateUrl: './ingrediente.component.html',
  styleUrls: ['./ingrediente.component.scss']
})
export class IngredienteComponent implements OnInit {

  
  form: any = {
    nume: null,
    unitate_Masura:  null,
    categorie: null

  };
  isSuccessful = false;
  isFailedIngredient = false;
  errorMessage = '';

  ingredient = new FormControl('');

  subscription = new Subscription();
  listaIngrediente: any = [];

  url='https://localhost:5001/api/ingredient/all';

  constructor(private allI: AllIngredienteService) { }

  ngOnInit(): void {
    this.AllIngrediente(this.url);
  }

  onSubmit(): void {
    const { nume, unitate_Masura, categorie} = this.form;
    console.log(nume, unitate_Masura, categorie);
    this.allI.postIngredient(nume, unitate_Masura, categorie).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isFailedIngredient = false;
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isFailedIngredient = true;
      }
    });
  }


  public AllIngrediente(url: string){
    this.subscription.add(
      this.allI.AllIngrediente(url)
      .subscribe(ingr=>{
        console.log(ingr[0].ingredient)
        this.listaIngrediente = ingr;
      },)
    );
  }
}
