import { ApiProveedorService } from './../services/apiProveedor.service';
import { Component, OnInit } from '@angular/core';
import { Proveedor } from '../models/proveedor';
import { DialogProveedorComponent } from './dialog/dialogProveedor.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogDeleteComponent } from '../common/delete/dialogdelete.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app-proveedor',
    templateUrl: './proveedor.component.html',
    styleUrls: ['./proveedor.component.scss']
  })
export class ProveedorComponent implements OnInit{

    public lst: any[] =[];
    public columnas: string[]=['id','nombre','telefono','tipoidentificacion', 'noidentificacion','estado','actions'];
    readonly width: string="100%"; 
    readonly widthdelete: string="300px";
    readonly maxwidth: string="500px"; 
    constructor(public apiProveedor: ApiProveedorService,
        public dialog: MatDialog,
        private titleService: Title,
        public snackBar: MatSnackBar){
            this.titleService.setTitle("Proveedores");

    }

    getProveedores(){
        this.apiProveedor.getProveedores().subscribe(res =>{
            this.lst = res.datos;
        });
    }

    delete(proveedor: Proveedor){
        const dialogRef = this.dialog.open(DialogDeleteComponent, {
            width: this.widthdelete
          });
          dialogRef.afterClosed().subscribe(result =>{
            if(result){
              this.apiProveedor.delete(proveedor).subscribe(response => {
                if(response.exito==1){
                  this.snackBar.open('El Proveedor fue eliminado con éxito','',{duration:2000});
                  this.getProveedores();
                }
              })
            }
          })
    }

    openEdit(proveedor: Proveedor){
        const dialogRef = this.dialog.open(DialogProveedorComponent, {
            width: this.width,
            maxWidth: this.maxwidth,
            data: proveedor
          });
          dialogRef.afterClosed().subscribe(result =>{
            this.getProveedores();
          })
      }

      openAdd(){
        const dialogRef = this.dialog.open(DialogProveedorComponent, {
            width: this.width,
            maxWidth: this.maxwidth
          });
          dialogRef.afterClosed().subscribe(result =>{
            this.getProveedores();
          })
      }
    ngOnInit(){
       this.getProveedores();
    }
}