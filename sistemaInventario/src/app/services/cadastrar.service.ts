import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { CadastrarModule } from './cadastrar.module';
import { environment } from 'src/environments/environment';
import { Servidor } from 'src/app/model/servidor.model';

@Injectable({
  providedIn: 'root'
})
export class CadastrarService {

  //cadastrosUrl = 'http://172.18.105.247:52000/api/v1/equipamentos';

  constructor(private http: HttpClient) { }

  listar() {
    return this.http.get<Array<any>>(`${environment.baseUrl}/InventarioServidor`);
  }

criar(servidor: Servidor) {
    return this.http.post(`${environment.baseUrl}/InventarioServidor`, servidor);
  }

}