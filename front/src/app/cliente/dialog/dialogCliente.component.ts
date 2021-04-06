import { Response } from './../../models/response';
import { Identificacion } from './../../models/identificacion';
import { ApiClienteService } from './../../services/apiCliente.service';
import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Cliente } from 'src/app/models/cliente';
import {FormGroup, FormControl, FormBuilder, Validators, NgForm} from '@angular/forms';
import { OnInit } from '@angular/core';
import { ApiCategoriaService } from 'src/app/services/api-categoria.service';
import { Categoria } from 'src/app/models/categoria';


@Component({
    selector: 'dialogCliente.component',
    styleUrls: ['../cliente.component.scss'],
    templateUrl: 'dialogCliente.component.html'
})
export class DialogClienteComponent implements OnInit{
    public identificacionList: Identificacion[];


    public clienteForm = this.formBuilder.group({
        id: [0],
        nombre: ['', Validators.required],
        telefono: [''],
        direccion: [''],
        identificacion: [''],
        idtipoidentificacion: [null, Validators.required]
    })

    constructor(
        public dialogRef: MatDialogRef<DialogClienteComponent>,
        public apiCliente: ApiClienteService,
        public snackBar: MatSnackBar,
        private formBuilder: FormBuilder,
        @Inject(MAT_DIALOG_DATA) public cliente: Cliente
     ){
        if(this.cliente != null){
            const clienteValues =  {...this.cliente}    
            this.clienteForm.patchValue({
                ...clienteValues,
                idtipoidentificacion: clienteValues.ididentificacionType.id
            })
        }
     }

     getTipoIdentificacion(){
         this.apiCliente.getTipoIdentificacion().subscribe(res =>{
             this.identificacionList = res.datos;
         })
     }

     ngOnInit(){
        this.getTipoIdentificacion();
     }

     limpiar(){
         this.clienteForm.reset();
     }

     close(){
        this.dialogRef.close();
    }

   editCliente(){
    this.apiCliente.edit(this.clienteForm.value).subscribe(res =>{
        if(res.exito ==1){
            this.dialogRef.close();
            this.snackBar.open('Cliente editado con éxito','',{duration: 2000});
        }
    })
   }
    

    addCliente(){
        //const cliente: Cliente = this.clienteForm.value;
        this.apiCliente.add(this.clienteForm.value).subscribe(response =>{
            if(response.exito ==1){
                this.dialogRef.close();
                this.snackBar.open('Cliente insertado con éxito','',{duration: 2000});
            }
        });
    }




}