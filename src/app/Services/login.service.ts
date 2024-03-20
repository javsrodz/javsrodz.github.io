import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../environmet';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private enpoint: string = environment.apiUrl;
  private apiurl: string = this.enpoint;


  constructor(
    private router:Router,
    private http:HttpClient,
  ){

  }

 login(modelo:any){
  return this.http.post<any>(`${this.apiurl}login`, modelo);
 }

 nuevous(modelo:any){
  return this.http.post<any>(`${this.apiurl}nuevous`,modelo);
 }

 guardartoken(token:string){
  localStorage.setItem('token',token)
 }

 traertoken(){
  localStorage.getItem('token')
 }

 sesionactiva():boolean{
  return !!localStorage.getItem('token')
 }

 cerrarsesion(){
  localStorage.clear();
 }
}
