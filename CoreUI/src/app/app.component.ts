import { Component } from '@angular/core';
import { HttpService} from './services/httphandler/http.service';
import {AuthService} from './services/authhandler/auth.service';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  { 
  constructor(private httpService:HttpService, private authService:AuthService
    , private snackBar:MdSnackBar){}

  private isLoggedIn:boolean;


  get showLoading() { return this.isLoading; }

  private isLoading:boolean = false;

  ngOnInit(){
      this.isLoggedIn = this.authService.isLoggedIn();
      

      this.authService.userLoggedInSubject.subscribe(x => {
          this.isLoggedIn = x;
      });
  }

  ngAfterViewInit() {
    this.httpService.busyLoadingSubject.subscribe(x => setTimeout(() => {
      this.isLoading = x;
    }, 1)); 
  }
  
    logOut(){
        this.authService.signOut().subscribe(x => this.snackBar.open("Signed Out", null,{duration: 1000}));
    }

    get isAuthenticated(){
        return this.isLoggedIn;
    }
}
