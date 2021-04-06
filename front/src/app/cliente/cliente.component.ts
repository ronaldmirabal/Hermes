import { ApiClienteService } from './../services/apiCliente.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from '../models/cliente';
import { DialogDeleteComponent } from './../common/delete/dialogdelete.component';
import { DialogClienteComponent } from './dialog/dialogCliente.component';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html',
    styleUrls: ['./cliente.component.scss']
  })
export class ClienteComponent implements OnInit{
  public lst: any[] =[];
  public columnas: string[]=['id','nombre','telefono','tipoidentificacion', 'identificacion','estado','actions'];
  readonly width: string="100%"; 
  readonly maxwidth: string="500px"; 

    constructor( private apiCliente: ApiClienteService,
      public dialog: MatDialog,
      public snackBar: MatSnackBar) { }


  getClientes(){
      this.apiCliente.getClientes().subscribe( response => {
      this.lst = response.datos;
      });
  }


  openAdd(){
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      width: this.width,
      maxWidth: this.maxwidth
    });
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  openEdit(cliente: Cliente){
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      width: this.width, 
      maxWidth: this.maxwidth,
      data: cliente
    });
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  delete(cliente: Cliente){}
  ngOnInit(): void {
    this.getClientes();
  }
}