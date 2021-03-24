import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ApiCategoriaService } from 'src/app/services/api-categoria.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Categoria } from 'src/app/models/categoria';

@Component({
    templateUrl: 'dialogcategoria.component.html'
})
export class DialogCategoriaComponent{
    public nombre: string ='';
     constructor(
        public dialogRef: MatDialogRef<DialogCategoriaComponent>,
        public apiCategoria: ApiCategoriaService,
        public snackBar: MatSnackBar,
        @Inject(MAT_DIALOG_DATA) public categoria: Categoria
     ){
        if(this.categoria !== null){
            this.nombre = categoria.nombre;
        }
     }
     close(){
         this.dialogRef.close();
     }

     editCategoria(){
         const categoria: Categoria ={nombre: this.nombre, id: this.categoria.id}
         this.apiCategoria.edit(categoria).subscribe(response =>{
            if(response.exito ==1){
                this.dialogRef.close();
                this.snackBar.open('Categoria editada con éxito','',{duration: 2000});
            }
        });
     }

     addCategoria(){
         const categoria: Categoria ={nombre: this.nombre, id: 0};
         this.apiCategoria.add(categoria).subscribe(response =>{
             if(response.exito ==1){
                 this.dialogRef.close();
                 this.snackBar.open('Categoria insertada con éxito','',{duration: 2000});
             }
         });
     }
         
     
}