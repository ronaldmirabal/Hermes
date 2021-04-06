import { Articulo } from './../../models/articulo';
import { ApiArticuloService } from './../../services/apiArticulo.service';
import { Categoria } from 'src/app/models/categoria';
import { ApiCategoriaService } from 'src/app/services/api-categoria.service';
import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
    selector: 'dialogArticulo.component',
    templateUrl: './dialogArticulo.component.html',
    styleUrls: ['./dialogArticulo.component.scss']
})
export class DialogArticuloComponent implements OnInit{

    categoryList: Categoria[];
    
    isValid: boolean = true;
    constructor(public apiCategoria: ApiCategoriaService, 
        public apiArticulo: ApiArticuloService,
        public snackBar: MatSnackBar,
        public dialogRef: MatDialogRef<DialogArticuloComponent>,
        @Inject(MAT_DIALOG_DATA) public articulo: Articulo,
        private formBuilder: FormBuilder){
           
            //Detecta cuando el articulo es editable
            if(this.articulo != null){
                //debugger
                const articuloValues =  {...this.articulo}    
                this.articuloForm.patchValue({
                    ...articuloValues,
                    idcategoria: articuloValues.categoria.id
                })
               
    
            }
        }

    
      public articuloForm = this.formBuilder.group({
          id: [0],
          idcategoria: [null, Validators.required],
          nombre: ['', Validators.required],
          codigo: [''],
          precio: [0, Validators.required],
          descripcion: [''],
          tipo:['', Validators.required],
          estado: true,
          stock: [1],
          costo:[0],
          itbis:[0]
      })

    getCategorias(){
        this.apiCategoria.getCategorias().subscribe(res => {
            this.categoryList = res.datos;
        })
    }

    ngOnInit(){
        this.getCategorias();
    }

    limpiar(){
        this.articuloForm.reset();
    }
   

    editArticulo() {
       
        this.apiArticulo.edit(this.articuloForm.value).subscribe(response =>{
           if(response.exito ==1){
               this.dialogRef.close();
               this.snackBar.open('Articulo editado con éxito','',{duration: 2000});
           }
       });
    }

    addArticulo() {
        this.apiArticulo.add(this.articuloForm.value).subscribe(res => {
            if(res.exito ==1){
                this.dialogRef.close();
                this.snackBar.open('Articulo insertado con éxito','',{duration: 2000});
            }
        })
    }
    
}