import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { CadastrarComponent } from './cadastrar.component';
import { CadastrarService } from './cadastrar.service';

@NgModule({
  declarations: [
    CadastrarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [CadastrarService],
  bootstrap: [CadastrarComponent]
})

export class CadastrarModule {
    ip: string;
    hostname: string;
    observacao: string;
    status: string;
    tipoServidor: string;
    espacoDisco: string;
    cpu: string;
    memoria: string;
    conteudo: string;
    nomeAmbiente: string;
    nomeCategoriaBackup: string;
    descricao: string;
    nomeDataCenter: string;
    nomeFinalidade: string;
    nomeResponsabilidade: string;
    nomeSistemaOperacional: string;
    versao: string;
    distribuicao: string;
}