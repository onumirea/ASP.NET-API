import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AllreteteService } from '../services/allretete.service';
import { FormControl } from '@angular/forms';
import { RecenzieService } from '../services/recenzie.service';
import { RetetaService } from '../services/reteta.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-view-reteta',
  templateUrl: './view-reteta.component.html',
  styleUrls: ['./view-reteta.component.scss']
})
export class ViewRetetaComponent implements OnInit {

  form: any = {
    continut: null,
    rating:  null
  };
  isSuccessful = false;
  isFailedReteta = false;
  errorMessage = '';

  reteta_id: number;
  ret: any = {};
  rec: any = {};
  range: any = [];
  range1: any = [];
  rating_mediu: number = 0;
  constructor(
    private allRS: AllreteteService,
    private activateRoute: ActivatedRoute,
    private RS: RecenzieService,
    private retetaService: RetetaService,
    private tokenStorage: TokenStorageService
  ) { 
    this.reteta_id=this.activateRoute.snapshot.params['id'];
  }

  
  
  ngOnInit(): void {
    this.allRS.RetetaWithNume(this.reteta_id).subscribe((res: any)=>{console.log(res);this.ret=res});
    this.allRS.RecenziileRetetei(this.reteta_id).subscribe((res: any)=>{console.log(res);this.rec=res});
    this.allRS.RatingMediuReteta(this.reteta_id).subscribe((res: any)=>{console.log(res);this.rating_mediu=res});
    this.allRS.RatingMediuReteta(this.reteta_id).subscribe((res: any)=>{console.log(res);this.nrSteleGalbene(res)});
    this.allRS.RatingMediuReteta(this.reteta_id).subscribe((res: any)=>{console.log(res);this.nrSteleGri(res)});
    console.log(this.tokenStorage.getToken());
  }
  onSubmit(): void {
    const { continut, rating} = this.form;
    this.RS.postRecenzie(continut, rating, this.reteta_id).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isFailedReteta = false;
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isFailedReteta = true;
      }
    });
  }

  nrSteleGalbene(nr: any): void{
    for(var i=0; i< nr; i++ )
    this.range.push(i);
  }
  nrSteleGri(nr: any): void{
    for(var i=0; i< 5 - nr; i++ )
    this.range1.push(i);
  }
}
