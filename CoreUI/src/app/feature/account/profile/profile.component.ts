import { Component, OnInit } from '@angular/core';
import { UserModel, LookupModel } from '../../../models/models';
import { AuthService } from '../../../services/authhandler/auth.service';
import { MdSnackBar } from '@angular/material';
import { LookupsService } from '../../../services/lookups/lookups.service';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    constructor(private auth:AuthService,private snackBar:MdSnackBar, private lookupService:LookupsService){
    }
    establishmentTypes:LookupModel[];

    user:UserModel = new UserModel();  

    ngOnInit(){
        this.auth.getMe().subscribe(x => {this.user = x.json()});
        this.lookupService.getEstablishmentTypes().subscribe(res => {
            this.establishmentTypes = res;
        })
    }

    save() {
        this.auth.saveMe(this.user).subscribe(x => {
            this.user = x.json();
            this.snackBar.open("Successfully saved", "Close", {duration: 3000});
        });
    }

}
