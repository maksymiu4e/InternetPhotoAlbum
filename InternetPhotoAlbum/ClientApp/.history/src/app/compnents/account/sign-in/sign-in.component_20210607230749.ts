import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SignInViewModel } from 'src/app/models/sign-in.model';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  formGroup: FormGroup;
  constructor(private accountService: AccountService) { }

  onSignIn(signInModel: SignInViewModel) {
    this.accountService.signIn(signInModel);
  }

  ngOnInit() {
    this.formGroup = new FormGroup({
      ['email']: new FormControl(),
      ['password']: new FormControl()
    })

    console.log(this.formGroup.value)
  }

}
