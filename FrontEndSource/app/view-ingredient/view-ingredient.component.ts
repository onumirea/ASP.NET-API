import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AllIngredienteService } from '../services/allingrediente.service';

@Component({
  selector: 'app-view-ingredient',
  templateUrl: './view-ingredient.component.html',
  styleUrls: ['./view-ingredient.component.scss']
})
export class ViewIngredientComponent implements OnInit {
  nume_ingredient: string;
  ingr: any = {};
  constructor(
    private allI: AllIngredienteService,
    private activateRoute: ActivatedRoute
  ) { 
    this.nume_ingredient=this.activateRoute.snapshot.params['nume'];
  }

  ngOnInit(): void {
    this.allI.IngredWithName(this.nume_ingredient).subscribe((res: any)=>{console.log(res);this.ingr=res});
  }

}
