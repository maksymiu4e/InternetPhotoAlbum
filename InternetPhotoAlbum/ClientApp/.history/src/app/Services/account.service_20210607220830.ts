import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getBaseUrl } from 'src/main';
import { SignInViewModel } from '../Models/sign-in.model';
import { SignUpViewModel } from '../Models/sign-up.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  myApiUrl: string;
  constructor(private http: HttpClient) {
    this.myApiUrl = getBaseUrl();
  }

  signIn(singInModel: SignInViewModel) {
    return this.http.post(this.myApiUrl + 'signin', singInModel);
  }

  signOut() {
    return this.http.post(this.myApiUrl + 'signout', null);
  }

  signUp(signUpModel: SignUpViewModel) {
    return this.http.post(this.myApiUrl + 'signup', signUpModel);
  }
}
