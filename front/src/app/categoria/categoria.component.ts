import { DialogDeleteComponent } from './../common/delete/dialogdelete.component';
import { DialogCategoriaComponent } from './dialog/dialogcategoria.component';
import { Component, OnInit } from '@angular/core';
import { ApiCategoriaService } from '../services/api-categoria.service';
import { MatDialog} from '@angular/material/dialog';
import { Categoria } from '../models/categoria';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss']
})
export class CategoriaComponent implements OnInit {

  public lst: any[] =[];
  public columnas: string[]=['id','nombre','actions'];
  readonly width: string="300px"; 
  constructor(
    private apiCategoria: ApiCategoriaService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ) {
   
   }

  ngOnInit(): void {
    this.getCategorias();
  }

  getCategorias(){
    this.apiCategoria.getCategorias().subscribe( response => {
      this.lst = response.datos;
    });
  }

  openAdd(){
    const dialogRef = this.dialog.open(DialogCategoriaComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result =>{
      this.getCategorias();
    })
  }

  openEdit(categoria: Categoria){
    const dialogRef = this.dialog.open(DialogCategoriaComponent, {
      width: this.width, data: categoria
    });
    dialogRef.afterClosed().subscribe(result =>{
      this.getCategorias();
    })
  }


  delete(categoria: Categoria){
    const dialogRef = this.dialog.open(DialogDeleteComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result =>{
      if(result){
        this.apiCategoria.delete(categoria.id).subscribe(response => {
          if(response.exito==1){
            this.snackBar.open('Categoria eliminada con éxito','',{duration:2000});
            this.getCategorias();
          }
        })
      }
    })
  }

}
