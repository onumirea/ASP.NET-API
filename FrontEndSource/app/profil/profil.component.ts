import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.scss']
})
export class ProfilComponent implements OnInit {
  currentUser: any;

  constructor(public token: TokenStorageService) { }

  ngOnInit(): void {
    this.currentUser = this.token.getPayload();
  }
}