import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AllreteteService } from '../services/allretete.service';

@Component({
  selector: 'app-feluri-principale',
  templateUrl: './feluri-principale.component.html',
  styleUrls: ['./feluri-principale.component.scss']
})
export class FeluriPrincipaleComponent implements OnInit {

  subscription = new Subscription();
  listaRetete: any = [];

  url='https://localhost:5001/api/reteta/all';
  constructor(private allRS: AllreteteService) { }

  ngOnInit(): void {
    this.AllRetete(this.url);
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
