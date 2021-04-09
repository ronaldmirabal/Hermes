import { Cliente } from './../models/cliente';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from '../models/response';
import { environment } from 'src/environments/environment';

const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
  @Injectable({
    providedIn: 'root'
  })
export class ApiClienteService{
  formData: Cliente;
    constructor(
      private _http: HttpClient
    ) { }

    getClientes(): Observable<Response>{
        return this._http.get<Response>(`${environment.url}/cliente`);
      }

     

    add(cliente: Cliente):Observable<Response>{
        return this._http.post<Response>(`${environment.url}/cliente`,cliente,httpOption);
      }
    
    edit(cliente: Cliente):Observable<Response>{
        return this._http.put<Response>(`${environment.url}/cliente`,cliente,httpOption);
      }  

    
}