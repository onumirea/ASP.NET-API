import { Component, OnInit } from '@angular/core';
import { AutentificareService } from '../services/autentificare.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form: any = {
    nume: null,
    prenume: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private autentificareService: AutentificareService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const { nume, prenume, email, password } = this.form;

    this.autentificareService.register(nume, prenume, email, password).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    });
  }
}