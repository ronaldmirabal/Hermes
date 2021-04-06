import { Categoria } from 'src/app/models/categoria';
import { Response } from './../models/response';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';
import { Articulo } from '../models/articulo';


const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
  @Injectable({
    providedIn: 'root'
  })
  export class ApiArticuloService{
    formData: Categoria;
    constructor(
        private _http: HttpClient
      ) { }

      getArticulos(): Observable<Response>{
        return this._http.get<Response>(`${environment.url}/articulo`);
      }
      add(articulo: Articulo):Observable<Response>{
        return this._http.post<Response>(`${environment.url}/articulo`,articulo,httpOption);
      }
    
      edit(articulo: Articulo):Observable<Response>{
        return this._http.put<Response>(`${environment.url}/articulo`,articulo,httpOption);
      }
    
      delete(articulo: Articulo):Observable<Response>{
        return this._http.put<Response>(`${environment.url}/articulo/delete`,articulo,httpOption);
      }
  }