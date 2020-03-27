import { Component, OnInit } from '@angular/core';
import { Servidor } from 'src/app/model/servidor.model';
import { MethodService } from 'src/app/services/method.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm, FormGroup, FormBuilder } from '@angular/forms';
import { map, switchMap, sequenceEqual } from 'rxjs/operators';

@Component({  
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  formServidor: FormGroup;
  submitted = false;
  identificador: any;

  constructor
  (
    private editarService: MethodService, 
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) 
  { 
    //this.route.params.subscribe(params => this.id = params['id']);
  }

  ngOnInit(){
    //RESPONSAVEL POR PEGAR O ID DO SERVIDOR
    this.route.params
    .pipe(
      map((params: any) => params['id']),
      switchMap(id => this.editarService.idServidor(id))
    )
    .subscribe(
      //servidor => this.updateForm(servidor)      
    );
    
    
    const servidor = this.route.snapshot.data['servidor'];

    //CARREGA OS INPUTS DO FORM COM VALORES VAZIOS
    this.formServidor = this.fb.group({
      servidorID: [servidor.servidorID], ip: [servidor.ip], hostname: [servidor.hostname], observacao: [servidor.observacao], status: [servidor.status],
      tipoServidor: [servidor.tipoServidor], espacoDisco: [servidor.espacoDisco], cpu: [servidor.cpu], memoria: [servidor.memoria],
      conteudo: [servidor.conteudo], ambienteID: [servidor.ambienteID], nomeAmbiente: [servidor.nomeAmbiente], responsabilidadeID: [servidor.responsabilidadeID],
      nomeResponsabilidade: [servidor.nomeResponsabilidade], datacenterID: [servidor.datacenterID], nomeDataCenter: [servidor.nomeDataCenter],
      sistemaOperacionalID: [servidor.sistemaOperacionalID], nomeSistemaOperacional: [servidor.nomeSistemaOperacional], distribuicao: [servidor.distribuicao],
      versao: [servidor.versao], categoriaBackupID: [servidor.categoriaBackupID], nomeCategoriaBackup: [servidor.nomeCategoriaBackup],
      descricao: [servidor.descricao], finalidadeID: [servidor.finalidadeID], nomeFinalidade: [servidor.nomeFinalidade]
    })
  }

  onSubmit(){
    this.submitted = true;
    console.log(this.formServidor.value);
    this.editarService.atualizarServidor(this.formServidor.value).subscribe(
      success => {
        alert('Registro Alterado com sucesso');
        this.router.navigate(['/home']);
      },
      err => {
        alert('Erro ao atualizar registro ' + err);
      }
    )
  }

  atualizarServidor() {
    this.editarService.atualizarServidor(this.formServidor.value).subscribe();
  }
}
