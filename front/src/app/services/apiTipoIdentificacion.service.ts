import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Response } from "../models/response";

const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
  @Injectable({
    providedIn: 'root'
  })
export class ApiTipoIdentificacionService{
    constructor(
        private _http: HttpClient
      ) { }

      getTipoIdentificacion(): Observable<Response>{
        return this._http.get<Response>(`${environment.url}/identificacion`);
      } 
}