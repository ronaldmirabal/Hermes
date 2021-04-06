import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from '../models/categoria';
import { Response } from '../models/response';
import { environment } from 'src/environments/environment';
import {catchError,map,tap} from 'rxjs/operators';

const httpOption ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiCategoriaService {

 
  constructor(
    private _http: HttpClient
  ) { }


  getCategorias(): Observable<Response>{
    return this._http.get<Response>(`${environment.url}/categoria`);
  }
  
  getProjects(): Observable<any>{
    return this._http.get<Categoria>(`${environment.url}/categoria`);
  }
  
  handleError(arg0: string, arg1: undefined[]): (err: any, caught: Observable<any>) => import("rxjs").ObservableInput<any> {
    throw new Error('Method not implemented.');
  }
  

  add(categoria: Categoria):Observable<Response>{
    return this._http.post<Response>(`${environment.url}/categoria`,categoria,httpOption);
  }

  edit(categoria: Categoria):Observable<Response>{
    return this._http.put<Response>(`${environment.url}/categoria`,categoria,httpOption);
  }

  delete(id: number):Observable<Response>{
    return this._http.delete<Response>(`${environment.url}/categoria/${id}`);
  }

 


}
