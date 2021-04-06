import { Response } from './../models/response';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Factura } from "../models/factura";
import { environment } from 'src/environments/environment';

const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
@Injectable({
    providedIn: 'root'
})
export class ApiFacturaService{

    constructor(private _http: HttpClient){
    }

    getAll(): Observable<Response>{
      return this._http.get<Response>(`${environment.url}/factura`);
    }
    add(factura: Factura): Observable<Response>{
        return this._http.post<Response>(`${environment.url}/factura`,factura, httpOption)
    }
}