import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../../services/authhandler/auth.service';
import { MdSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { UserModel, LookupModel } from '../../../models/models';
import { LookupsService } from '../../../services/lookups/lookups.service';

@Component({
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
    constructor(
        private auth:AuthService, 
        private snackBar:MdSnackBar, 
        private router:Router,
        private lookupService:LookupsService){
    }

    user = new UserModel();
    establishmentTypes:LookupModel[];

    ngOnInit(){
        this.lookupService.getEstablishmentTypes().subscribe(res => {
            this.establishmentTypes = res;
        })
    }

    registerUser() {
        this.user.userName = this.user.email;
        this.auth.signUp(this.user).subscribe(response => {
            var resObj = response.json();
            var successful:boolean = resObj.requestSuccessful;

            if (successful){
                this.snackBar.open("Signed Up Successfully!", 'Close', {duration: 1000});
                this.router.navigate(['/']);
            }
            else
            {
                this.snackBar.open("Registration Unsuccesful: " + resObj.errorMessage, 'Close', {duration: 3000});                
            }
        });
    }

}
