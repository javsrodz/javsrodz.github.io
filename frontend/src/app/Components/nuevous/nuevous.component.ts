import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-nuevous',
  templateUrl: './nuevous.component.html',
  styleUrls: ['./nuevous.component.css']
})
export class NuevousComponent implements OnInit {

registro= new FormGroup({
  nombre: new FormControl('',Validators.required),
  apellidos: new FormControl('',Validators.required),
  correo: new FormControl('',Validators.required),
  pass: new FormControl('',Validators.required),
  puesto: new FormControl('',Validators.required),
  rol: new FormControl('',Validators.required),
});



constructor(public servicio:LoginService) {
  
}
  ngOnInit(): void {
    
  }



registrar(){
  console.log(this.registro.value);
const modelo ={
  "nombre":this.registro.value.nombre,
  "apellidos":this.registro.value.apellidos,
  "correo":this.registro.value.correo,
  "contrasena":this.registro.value.pass,
  "puesto":this.registro.value.puesto,
  "rol":this.registro.value.rol
}
if (this.registro.valid){
  this.servicio.nuevous(modelo).subscribe({
    next:(datos:any)=>{
      console.log("Usuario Registrado :)")
      alert("Usuario Registrado");
      this.registro.reset();
    },error:(e)=>{
      console.log(e + "Error al registrar el usuario");
    }
  });
}else{
  alert("Verifica los datos ingresados");
}
}



}
