import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {inject} from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthServices {
  private http = inject(HttpClient);

  login(email:string, password:string) {

    const body = { email, password };
    return this.http.post(`${environment.apiUrl}/api/user/login`, body)
  }

  register(email:string, password:string, cpf:string, cellphone:string, name:string) {
    const body = {name, email, cpf, cellphone, password};
    return this.http.post(`${environment.apiUrl}/api/user/register`, body)
  }
}

