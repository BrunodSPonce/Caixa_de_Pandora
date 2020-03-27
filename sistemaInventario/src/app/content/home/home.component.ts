import {Component, OnInit, ViewChild} from '@angular/core';
import { MatSort } from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { HomeService } from './home.service';
import { Servidor } from 'src/app/model/servidor.model';
import { Router } from '@angular/router';
import { MethodService } from 'src/app/services/method.service';

/**
 * @title Table with pagination
 */
@Component({
  selector: 'app-home',
  styleUrls: ['home.component.css'],
  templateUrl: 'home.component.html',
})

export class HomeComponent implements OnInit {

  servidores: Array<MatTableDataSource<any>> = new Array();

  servidorId : any;

  constructor(
    private homeService: MethodService,
    private router: Router
  ){}


  displayedColumns: string[] = [
    'ip', 'hostname', 'observacao', 'status', 'tipoServidor', 'espacoDisco', 'cpu',
    'memoria', 'conteudo'
  ];
  

  
  ngOnInit() {
    
    this.listarServidores();  
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  edit(servidorID) {
    this.router.navigate(['editar', servidorID])
  }

  listarServidores() : any{
    this.homeService.listarServidores().subscribe(servidores => {
      this.servidores = servidores;
    }, err =>{
      console.log('Erro ao carregar lista de servidores', err);
    })
  }
  
  dataSource = new MatTableDataSource<Servidor>();
  
  servidorPorId(){
    this.homeService.idServidor(this.servidorId).subscribe(servidorId =>{
      this.servidorId = servidorId;
    }, err =>{
      console.log('Não encontrado')
    })
  }

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  // Filtro da tabela
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove Espaço em branco
    filterValue = filterValue.toLowerCase(); // Define como letras minusculas
    this.dataSource.filter = filterValue;
  }
}
