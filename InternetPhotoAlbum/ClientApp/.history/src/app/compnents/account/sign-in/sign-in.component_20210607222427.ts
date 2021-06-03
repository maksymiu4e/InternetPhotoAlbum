import { Component, OnInit } from '@angular/core';
import { SignInViewModel } from 'src/app/models/sign-in.model';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  onSignIn(signInModel: SignInViewModel) {
    this.accountService.signIn(signInModel);
  }

  ngOnInit() {
  }

}
