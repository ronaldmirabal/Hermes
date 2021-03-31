import { ApiauthService } from './../services/apiauth.service';
import { Injectable } from '@angular/core';
import {Router, CanActivate, ActivatedRouteSnapshot,RouterStateSnapshot} from '@angular/router';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate{

    constructor(private router: Router, private ApiauthService: ApiauthService){

    }
    canActivate(route: ActivatedRouteSnapshot){
            const usuario = this.ApiauthService.usuarioData;
            if(usuario){
                return true;
            }
            this.router.navigate(['/login']);
            return false;
      }
}