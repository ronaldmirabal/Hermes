import { Response } from './../models/response';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from '../models/user';
import {map} from 'rxjs/operators';



const httpOption ={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
@Injectable({
    providedIn: 'root'
})

export class ApiauthService{
    url: string ='https://localhost:44399/api/account/login';
    private userSubject: BehaviorSubject<User>;

    public get usuarioData(): User{
      return this.userSubject.value;
    }

    constructor(private _http: HttpClient){
      this.userSubject = 
      new BehaviorSubject<User>(JSON.parse(localStorage.getItem('User')|| '{}'));
    }


    login(username: string, password: string): Observable<Response>{
        return this._http.post<Response>(this.url,{username,password},httpOption).pipe(
          map(res =>{
            if(res.exito==1){
              const usuario: User = res.datos;
              localStorage.setItem('User',JSON.stringify(usuario));
              this.userSubject.next(usuario);
            }
            return res;
          })
        );

    }

    logout(){
      localStorage.removeItem('User');
      localStorage.clear();
    }

}