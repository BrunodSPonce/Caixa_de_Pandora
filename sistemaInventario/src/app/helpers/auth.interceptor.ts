/* 
  SERVICO RESPONSAVEL POR INTERCEPTAR E ARMAZENAR INFORMACOES DO TOKEN REGISTRADO NA API
*/

import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.tokenacesso) {
      request = request.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          Authorization: `bearer ${currentUser.tokenacesso}`
        }
      });
    }

    return next.handle(request);
  }
}
