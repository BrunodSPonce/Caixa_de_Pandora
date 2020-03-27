import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { MethodService } from 'src/app/services/method.service';
import { Servidor } from 'src/app/model/servidor.model';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css']

})

export class CadastrarComponent implements OnInit {

  cadastro:any;
  cadastros:Array<any>;
  ambientes:Array<any>;
  backups:Array<any>;
  datacenters:Array<any>;
  finalidades:Array<any>;
  responsaveis:Array<any>;
  sistemasoperacionais:Array<any>;

  constructor(private service: MethodService, private http: HttpClient){}

  ngOnInit() {
    this.cadastro = {};

    this.service.listar()
      .subscribe(resposta => this.cadastros = resposta);

  
    this.service.listarAmbiente()
    .subscribe(ambientes => this.ambientes = ambientes);

  
    this.service.listarCategoriaBackup()
    .subscribe(backups => this.backups = backups);

    
    this.service.listarDataCenter()
    .subscribe(datacenters => this.datacenters = datacenters);

    
    this.service.listarFinalidade()
    .subscribe(finalidades => this.finalidades = finalidades);

    
    this.service.listarResponsabilidade()
    .subscribe(responsaveis => this.responsaveis = responsaveis);

    
    this.service.listarSistemaOperacional()
    .subscribe(sistemasoperacionais => this.sistemasoperacionais = sistemasoperacionais);

    }

  criar(frm: FormGroup) {
    this.service.criar(this.cadastro).subscribe();
  }

  
  listarServidores() : any{
    this.service.listarServidores().subscribe(servidores => {
      this.cadastros = servidores;
    }, err =>{
      console.log('Erro ao carregar lista de servidores', err);
    })
  }
  /*
  criar() {
    this.service.criar(this.cadastro).subscribe(cadastro => {
      this.cadastro = cadastro;
      console.log('Teste');
    })
  }
  */
}