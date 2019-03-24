import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators/map';
import { User } from '../model/user';

@Injectable()
export class AuthService {

  protected baseUrl: string;
  public loggedIn: boolean;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/v1/account/';
  }

  public isLoggedIn() : boolean {
    return this.loggedIn;
  }


  public register(user: User) {
    return this.httpClient.post(this.baseUrl + 'register', user).pipe(map(_ => true));
  }


  public login(user: User) {
    return this.httpClient.post(this.baseUrl + 'login', user).
      //pipe(
      //  map(res => res.json())).
      pipe(
        map(res => {
          localStorage.setItem('auth_token', res['auth_token']);
          this.loggedIn = true;
          //this._authNavStatusSource.next(true);
          return true;
      }));
  }
}
