import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CadastrarModule } from './cadastrar.module';

@Injectable({
  providedIn: 'root'
})
export class CadastrarService {

  cadastrosUrl = 'https://localhost:44336/api/inventarioservidor';

  constructor(private http: HttpClient) { }

  listar() {
    return this.http.get<Array<any>>(this.cadastrosUrl);
  }

  listarSistemaOperacional(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/sistemaoperacional');
  }
  listarDataCenter(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/datacenter');
  }
  listarCategoriaBackup(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/backup');
  }
  listarAmbiente(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/ambiente');
  }
  listarFinalidade(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/finalidade');
  }
  listarResponsabilidade(){
    return this.http.get<Array<any>>('https://localhost:44336/api/inventarioservidor/responsabilidade');
  }

  criar(cadastro:CadastrarModule) {
    return this.http.post(this.cadastrosUrl, cadastro);
  }

}