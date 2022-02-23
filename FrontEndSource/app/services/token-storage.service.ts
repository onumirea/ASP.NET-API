import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { windowWhen } from 'rxjs';
import { Router } from '@angular/router';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor(
    private router:Router
  ) { }

  signOut(): void {
    window.sessionStorage.clear();
    window.location.reload();
  }

  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, user.token);
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    var JWTHS: JwtHelperService = new JwtHelperService();
    if (user) {
      return JWTHS.decodeToken(user!).email;
    }

    return {};
  }
  public getPayload(): any{
    const user = window.sessionStorage.getItem(USER_KEY);
    var JWTHS: JwtHelperService = new JwtHelperService();
    console.log(JWTHS.decodeToken(user!));
    return JWTHS.decodeToken(user!);
  }
}