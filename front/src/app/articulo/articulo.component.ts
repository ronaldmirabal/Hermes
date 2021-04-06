import { DialogArticuloComponent } from './dialog/dialogArticulo.component';
import { ApiArticuloService } from './../services/apiArticulo.service';
import { Component, OnInit } from '@angular/core';
import { Articulo } from '../models/articulo';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogDeleteComponent } from '../common/delete/dialogdelete.component';
import { Title } from '@angular/platform-browser';


@Component({
    templateUrl: './articulo.component.html',
    styleUrls: ['./articulo.component.scss']
  })
export class ArticuloComponent implements OnInit{
    public lst: any[] =[];
    public columnas: string[]=['id','codigo', 'nombre','precio','stock','estado','categoria','costo','impuesto','tipo', 'actions'];
    readonly width: string="100%"; 
    readonly maxwidth: string="500px"; 
    constructor(
        private apiArticulo: ApiArticuloService,
        public dialog: MatDialog,
        private titleService: Title,
        public snackBar: MatSnackBar
      ) {
          this.titleService.setTitle("Lista de Articulos");
       }

       getArticulos(){
        this.apiArticulo.getArticulos().subscribe( response => {
          this.lst = response.datos;
        });
      }

    openAdd(){
        const dialogRef = this.dialog.open(DialogArticuloComponent, {
            width: this.width,
            maxWidth: this.maxwidth
          });
          dialogRef.afterClosed().subscribe(result =>{
            this.getArticulos();
          })
    }
    openEdit(articulo: Articulo){
      const dialogRef = this.dialog.open(DialogArticuloComponent, {
        width: this.width, 
        maxWidth: this.maxwidth,
        data: articulo
      });
      dialogRef.afterClosed().subscribe(result =>{
        this.getArticulos();
      })
    }
    
    delete(articulo: Articulo){
      const dialogRef = this.dialog.open(DialogDeleteComponent, {
        width: this.width
      });
      dialogRef.afterClosed().subscribe(result =>{
        if(result){
          this.apiArticulo.delete(articulo).subscribe(response => {
            if(response.exito==1){
              this.snackBar.open('Articlulo Desactivado con éxito','',{duration:2000});
              this.getArticulos();
            }
          })
        }
      })
    }
    
    ngOnInit(){
      this.getArticulos();
    }
}