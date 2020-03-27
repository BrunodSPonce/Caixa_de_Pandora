import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { AuthService } from '../services/auth.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    error = '';
    posts: any;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private http: HttpClient
    ) {

      if (this.authService.currentUserValue) {
        this.router.navigate(['/']);
      }
    }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.returnUrl = this.route.snapshot.queryParams[' returnUrl '] || '/';
  }

  // CAPTURA AS REQUISIÇÕES PARA A API
  getPost() {
    this.http.get(`${environment.baseUrl}\login`).subscribe(res => {
      this.posts = res;
    },
    err => {
      alert('Usuario ou senha incorretos')
    }
    );
  }

  //RETORNA OS DADOS DIGITADOS NO FOMRULARIO
  get f() { return this.loginForm.controls; }

  //BOTÃO DE AÇÃO DO FORM
  onSubmit() {
    this.submitted = true;

    //VALIDAÇÃO DE DADOS DO FORM, CAMPO "ERROR" TRAVA EM CASO DE USUARIO INCORRETO
    if (this.loginForm.invalid) {
      alert('Por gentileza Informe os dados solicitados');
      this.loading = false;
    } else {
      this.loading = true;
      this.authService.login(this.f.username.value, this.f.password.value)
        .pipe(first())
        .subscribe(
          data => {
            this.router.navigate(['/home']);
          },
          error => {
            this.error = error;
            this.loading = false;
            this.getPost();
          }
        );
    }

  }


}
