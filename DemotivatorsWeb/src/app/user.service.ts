import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  get UserName(): string {
    return localStorage.getItem('userName');
  }

  set UserName(userName: string) {
    localStorage.setItem('userName', userName);
  }

  get IsLogged(): boolean {
    return localStorage.getItem('userName') != null;
  }
}
