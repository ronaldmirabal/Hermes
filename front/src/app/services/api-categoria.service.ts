import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from '../models/categoria';
import { Response } from '../models/response';

const httpOption ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiCategoriaService {

  url: string ='https://localhost:44399/api/categoria';
  constructor(
    private _http: HttpClient
  ) { }


  getCategorias(): Observable<Response>{
    return this._http.get<Response>(this.url);
  }

  add(categoria: Categoria):Observable<Response>{
    return this._http.post<Response>(this.url,categoria,httpOption);
  }

  edit(categoria: Categoria):Observable<Response>{
    return this._http.put<Response>(this.url,categoria,httpOption);
  }

  delete(id: number):Observable<Response>{
    return this._http.delete<Response>(`${this.url}/${id}`);
  }


}
