import { Component, OnInit } from '@angular/core';
import { ApiCategoriaService } from '../services/api-categoria.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss']
})
export class CategoriaComponent implements OnInit {

  public lst: any[] =[];
  public columnas: string[]=['id','nombre'];
  constructor(
    private apiCategoria: ApiCategoriaService
  ) {
   
   }

  ngOnInit(): void {
    this.getCategorias();
  }

  getCategorias(){
    this.apiCategoria.getCategorias().subscribe( response => {
      this.lst = response.datos;
    })
  }

  openAdd(){
    console.log("algo");
  }

}
