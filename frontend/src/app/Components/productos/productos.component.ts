import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  
  constructor(
    private servicio:LoginService
  ) 
  {  
    
  }


listapesonajes:any;

  ngOnInit(): void {

  }

}
