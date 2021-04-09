import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Response } from '../models/response';
import { environment } from 'src/environments/environment';
import { Proveedor } from '../models/proveedor';

const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
  @Injectable({
    providedIn: 'root'
  })
export class ApiProveedorService{

    constructor(
        private _http: HttpClient
      ) { }
      
    getProveedores():Observable<Response>{
        return this._http.get<Response>(`${environment.url}/proveedor`);
    }

    add(proveedor : Proveedor):Observable<Response>{
        return this._http.post<Response>(`${environment.url}/proveedor`,proveedor, httpOption);
    }
    edit(proveedor : Proveedor): Observable<Response>{
      return this._http.put<Response>(`${environment.url}/proveedor`,proveedor, httpOption);
    }
    delete(proveedor : Proveedor): Observable<Response>{
      return this._http.put<Response>(`${environment.url}/proveedor/delete`,proveedor, httpOption);
    }

}