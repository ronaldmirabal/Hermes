import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import {MediaMatcher} from '@angular/cdk/layout';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';
import { ApiauthService } from 'src/app/services/apiauth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnDestroy {
  panelOpenState = false;
  mobileQuery: MediaQueryList;
  private userSubject: BehaviorSubject<User>;
  usuario: User;

  

    public get usuarioData(): User{
      return this.userSubject.value;
    }

  fillerNav = [
  {name:"Home",route:"home",icon:"home"}
  ]

  fillerContent = Array.from({length: 50}, () =>
      ``);

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,public apiauthService: ApiauthService,
    private router: Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.apiauthService.usuario.subscribe(res =>{
      this.usuario = res;
    })
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  logout(){
    this.apiauthService.logout();
    this.router.navigate(['/login'])
  }
 

  shouldRun = true;
}
