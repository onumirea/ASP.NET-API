import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';
import { AllreteteService } from '../services/allretete.service';//

@Component({
  selector: 'app-reteta',
  templateUrl: './reteta.component.html',
  styleUrls: ['./reteta.component.scss']
})
export class RetetaComponent implements OnInit {
  @Input() ret: any;

  constructor(
    private allRS: AllreteteService,//
    private router:Router
  ) { }

  ngOnInit(): void {
  }
  goToRetetaPage(id: number): void{
    this.router.navigateByUrl("/view-reteta/"+id);
  }


  
}
