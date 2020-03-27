import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  listarServidores() : Observable<any>{
    return this.http.get(`${environment.baseUrl}/InventarioServidor`);
  }

  servidorPorId(id) : Observable<any>{
    return this.http.get(`${environment.baseUrl}/InventarioServidor/` + id);
  }

}
