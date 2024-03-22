import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot,CanActivate,Router,RouterStateSnapshot,UrlTree} from "@angular/router";
import { Observable } from "rxjs";
import { LoginService } from "../Services/login.service";

@Injectable({
  providedIn:'root'
})

export class guardaGuard implements CanActivate{
  
  
  constructor(private slogin:LoginService,
    private router:Router) {    
  
  }

  canActivate():boolean{
    if (this.slogin.sesionactiva()){
      return true;
    }else{
      this.router.navigate(['']);
      alert('Por favor inicia sesión');
      return false;
    }
  }
}

