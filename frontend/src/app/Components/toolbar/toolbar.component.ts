import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit{
  
  sesionactiva=false;

  ngOnInit(): void {
    let sesion = localStorage.getItem('token');
    if(sesion){
      this.sesionactiva=true;
    }else{
      this.sesionactiva =false;
    }

  }

  constructor(private router:Router,
    private slogin:LoginService){

  }

  login(){
    this.router.navigate(['login']);
  }
  home(){
    this.router.navigate(['']);
  }
  productos(){
    this.router.navigate(['productos']);
  }
  contacto(){
    this.router.navigate(['contacto']);
  }

  admin(){
    this.router.navigate(['admin']);
  }


  logout(){
    this.slogin.cerrarsesion();
    this.router.navigate(['']);
    alert('Sesión finalizada');
  }
}
