import { Factura } from './../models/factura';
import { ApiFacturaService } from './../services/apiFactura.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.scss']
})
export class FacturaComponent implements OnInit {
  public lst: any[] =[];
  public columnas: string[]=['id','no','cliente','fecha','total','tipocomprobante','nfc', 'actions'];
  constructor(private apiFactura: ApiFacturaService,private titleService: Title) { 
    this.titleService.setTitle("Lista De Factura");
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.apiFactura.getAll().subscribe(res =>{
      this.lst = res.datos;
    })
  }

  delete(factura: Factura){

  }

}
