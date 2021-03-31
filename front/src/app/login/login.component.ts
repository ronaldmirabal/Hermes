import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ApiauthService } from '../services/apiauth.service';



@Component({
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
  })
export class LoginComponent implements OnInit{

    public username: string = '';
    public password: string = '';
    constructor(public apiauth: ApiauthService, private router: Router){
        if(this.apiauth.usuarioData){
            this.router.navigate(['/'])
        }
    }
    ngOnInit(){

    }

    login(){
        this.apiauth.login(this.username, this.password).subscribe(response =>{
            console.log(response);
            if(response.exito==1){
                this.router.navigate(['/']);
            }
        })
    }
}