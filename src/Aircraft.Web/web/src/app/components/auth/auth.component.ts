import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth-service';
import { StorageKeys } from 'src/app/storage/storage-keys';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})

export class AuthComponent {
  authForm: FormGroup;
  isSubmitted: boolean = false;

  constructor(private serviceApi: AuthService, formBuilder: FormBuilder, private titleService: Title, private router: Router) {
    this.titleService.setTitle("Sign In");

    this.authForm = formBuilder.group({
      login: ['', Validators.compose([Validators.required, Validators.maxLength(300)])],
      password: ['', Validators.compose([Validators.required])],
    });
  }

  onSubmit() {
    if (!this.authForm.valid) {
      this.isSubmitted = true;
      return;
    }

    this.serviceApi.signIn(this.authForm.value).then(response => {
      localStorage.setItem(StorageKeys.AUTH_TOKEN, response.token);
      localStorage.setItem(StorageKeys.USER_ID, response.userId);

      this.router.navigate(['/maintenance-list']);

    }).catch(err => {

      alert("Erro ao logar na plataforma");
    });
  }
}
