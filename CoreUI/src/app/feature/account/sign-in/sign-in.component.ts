import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/authhandler/auth.service';
import { Router } from '@angular/router';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private auth:AuthService, private router:Router, private snackBar: MdSnackBar) { }

  ngOnInit() {
  }

  submit() {
      this.auth.signIn(this.user.userName, this.user.password).subscribe(x => {
          if (x.requestSuccessful)
          {
            this.router.navigate(['/']);
            this.snackBar.open("Signed in successfully", null,{duration: 1000});
          }
          else{
            this.snackBar.open("Sign in failed. Wrong email or password.", null,{duration: 1000});              
          }
      });
  }

  user:{
      userName: string,
      password:string
  } = {userName: '', password: ''};  


}
