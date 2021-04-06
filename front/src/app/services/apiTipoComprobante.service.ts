import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
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
export class ApiTipoComprobanteService{
    constructor(private _http: HttpClient){
    }

    getAll(): Observable<Response>{
        return this._http.get<Response>(`${environment.url}/tipocomprobante`);
    }
}