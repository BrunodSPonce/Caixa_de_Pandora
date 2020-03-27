/* 
  SERVICO RESPONSAVEL POR CAPTURAR AS REQUISICOES REALIZADAS NO ANGULAR PARA A API
*/

import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch'

import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const cloneReq = request.clone({
      headers: request.headers.set('Authorization', 'Bearer token')
    });
    
    return next.handle(cloneReq)
    .do((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        console.log('OK')
      }
    }).catch(result => {
      if (result instanceof HttpErrorResponse) {
        console.log(result);
      }

      return Observable.throw(result);
    });
  }
}
