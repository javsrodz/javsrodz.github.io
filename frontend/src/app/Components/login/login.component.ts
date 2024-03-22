import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  formLogin = new FormGroup({
    us: new FormControl('',[Validators.required,Validators.minLength(8),Validators.email]),
    pass: new FormControl('',[Validators.required,Validators.minLength(8)])
  });


//

constructor(private title:Title,
  private router:Router,
  private sLogin:LoginService){
  this.title.setTitle('Login')
}



  ngOnInit(): void {
    this.info();
  }


  login(){
    const modelo={
      user:this.formLogin.value.us,
      password:this.formLogin.value.pass
    }
    if (this.formLogin.valid){
      this.sLogin.login(modelo).subscribe({
        next:(respuesta:any)=>{
          console.log("login exitoso");
          this.router.navigate(['admin']);
          this.formLogin.reset();
          this.sLogin.guardartoken(respuesta.token);
        },error:(e)=>{
          console.log("error al acceder");
          alert("ERROR AL ACCEDER");
        }
      });
    }else{
      alert('verifica los datos ingresados');
      console.log('verifica los datos ingresados');
    }
} 

validarDominio(control:any) {
  const dominioRegExp = /^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

  if (control.value && !dominioRegExp.test(control.value)) {
    return { dominioInvalido: true };
  }

  return null;
}

 

  info(){
    console.log('menu de opciones')
  }

  nuevous(){
    this.router.navigate(['registrar']);
  }
}
