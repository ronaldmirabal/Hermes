import { ApiProveedorService } from './../../services/apiProveedor.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ApiTipoIdentificacionService } from './../../services/apiTipoIdentificacion.service';
import { Identificacion } from './../../models/identificacion';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Proveedor } from 'src/app/models/proveedor';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
    selector: 'dialogProveedor.component',
    styleUrls: ['../proveedor.component.scss'],
    templateUrl: 'dialogProveedor.component.html'
})
export class DialogProveedorComponent implements OnInit{

    public identificacionList: Identificacion[];

    constructor(
        public apiTipoIdentificacion: ApiTipoIdentificacionService,
        public dialogRef: MatDialogRef<DialogProveedorComponent>,
        public apiProveedor: ApiProveedorService,
        public snackBar: MatSnackBar,
        private formBuilder: FormBuilder,@Inject(MAT_DIALOG_DATA) public proveedor: Proveedor
    ){
        if(this.proveedor != null){
            const proveedorValues =  {...this.proveedor}    
            this.proveedorForm.patchValue({
                ...proveedorValues,
                idtipoidentificacion: proveedorValues.ididentificacionType.id
            })
        }
    }

    public proveedorForm = this.formBuilder.group({
        id: [0],
        nombre: ['', Validators.required],
        telefono: [''],
        direccion: [''],
        noidentificacion: [''],
        idtipoidentificacion: [null, Validators.required]
    })

    getTipoIdentificacion(){
        this.apiTipoIdentificacion.getTipoIdentificacion().subscribe(res =>{
            this.identificacionList = res.datos;
        });
    }

    limpiar(){
    }
    editProveedor(){
        this.apiProveedor.edit(this.proveedorForm.value).subscribe(res =>{
            if(res.exito ==1){
                this.dialogRef.close();
                this.snackBar.open('Proveedor editado con éxito','',{duration: 2000});
            }
        })
    }
    close(){
        this.dialogRef.close();
    }

    addProveedor(){
        this.apiProveedor.add(this.proveedorForm.value).subscribe(res =>{
            if(res.exito ==1){
                this.close();
                this.snackBar.open('Proveedor agregado con éxito','',{duration:2000});
            }
        })
    }
    ngOnInit(){
        this.getTipoIdentificacion();
    }
}