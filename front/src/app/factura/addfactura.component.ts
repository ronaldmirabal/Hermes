import { ApiTipoComprobanteService } from './../services/apiTipoComprobante.service';
import { ApiClienteService } from './../services/apiCliente.service';
import { DetalleFactura } from './../models/detalleFactura';
import { Factura } from './../models/factura';
import { ApiFacturaService } from './../services/apiFactura.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Cliente } from '../models/cliente';
import { TipoComprobante } from '../models/tipoComprobante';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
    styleUrls: ['./factura.component.scss'],
    templateUrl: './addfactura.component.html'
  })
export class AddFacturaComponent implements OnInit{
    
    public factura: Factura;
    clienteList: Cliente[];
    tipoComprobanteList: TipoComprobante[];
    public detalleFactura: DetalleFactura[];


    options: string[] = ['One', 'Two', 'Three'];
   filteredOptions: Observable<string[]>;

    public detalleForm = this.formBuilder.group({
        cantidad: [0, Validators.required],
        precio: [0],
        idcliente:[0, Validators.required],
        idTipoComprobante:[0, Validators.required],
        total: [0, Validators.required],
        idarticulo: [27, Validators.required]
    })
    myControl = new FormControl();

    constructor(public snackbar: MatSnackBar,
        public apiFactura: ApiFacturaService,
        private titleService: Title,
        public apiTipoComprobante: ApiTipoComprobanteService,
        public apiCliente: ApiClienteService,
        private formBuilder: FormBuilder){
            this.detalleFactura = [];
            this.factura = {idcliente:1,detallefacturas: [], idTipoComprobante:0};
            this.titleService.setTitle("Crear Factura");
    }

    addDetalle(){
        this.detalleFactura.push(this.detalleForm.value);
    }

    getClientes(){
        this.apiCliente.getClientes().subscribe(res =>{
            this.clienteList = res.datos;
        })
    }
    getTipoComprobantes(){
        this.apiTipoComprobante.getAll().subscribe(res =>{
            this.tipoComprobanteList = res.datos;
        })
    }

    addFactura(){
        this.factura.detallefacturas = this.detalleFactura;
        this.apiFactura.add(this.factura).subscribe(res =>{
            if(res.exito ==1){
                this.snackbar.open('Factura Realizada','',{duration:2000});
            }
        })
    }

    ngOnInit(){
        this.getClientes();
        this.getTipoComprobantes();

        this.filteredOptions = this.myControl.valueChanges
        .pipe(
            startWith(''),
            map(value => this._filter(value))
        );
    }

    private _filter(value: string): string[] {
        const filterValue = value.toLowerCase();
    
        return this.options.filter(option => option.toLowerCase().includes(filterValue));
      }
}