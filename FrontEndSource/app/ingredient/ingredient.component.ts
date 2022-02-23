import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.scss']
})
export class IngredientComponent implements OnInit {
  @Input() ingr: any;
  constructor(
    private router:Router
  ) { }

  ngOnInit(): void {
    console.log(this.ingr);
  }
  goToIngredientPage(nume: string): void{
    this.router.navigateByUrl("/view-ingredient/"+nume);
  }
}
