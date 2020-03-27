import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, tap, take } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Servidor } from '../model/servidor.model';


@Injectable({
  providedIn: 'root'
})
export class MethodService {
  constructor(
    private http: HttpClient
  ) 
  {}

  //METODO RESPONSAVEL PELO POST
  criar(servidor: Servidor) {
    return this.http.post(`${environment.baseUrl}/InventarioServidor`, servidor);
  }

  //METODO RESPONSAVEL PELO GET GERAL
  listarServidores() : Observable<any>{
    return this.http.get(`${environment.baseUrl}/InventarioServidor`);
  }

  //METODO RESPONSAVEL PELO GET POR IP
  idServidor(servidorID): Observable<Servidor> {
    return this.http.get<Servidor>(`${environment.baseUrl}/InventarioServidor` + '/' + servidorID)
      .pipe(
        take(1),
        retry(2),
        catchError(this.handleError)
      );
  }

  atualizarServidor(servidor){
    return this.http.put(`${environment.baseUrl}/InventarioServidor/${servidor.servidorID}`, servidor).pipe(
      take(1),
      catchError(this.handleError)
    );
  }

  //METODO RESPONSAVEL POR CAPTURAR ERROS
  handleError(erro: HttpErrorResponse) {
    let errorMessage = '';
    if (erro.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = erro.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${erro.status}, ` + `mensagem: ${erro.message}`;
    }
    //console.log(errorMessage);
    return throwError(errorMessage);
  }

}