import { Http, Headers, RequestOptions, Jsonp } from '@angular/http';
import {StorageService} from '../storagehandler/storage.service';
import {Router} from '@angular/router';
import {Injectable } from '@angular/core';
import {Subject} from 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
 
var baseURL = 'http://localhost:35970/';
var webApiURL = baseURL + 'api/';
var authURL = baseURL + 'auth/';
var homePage = '/';
var signUpPage = '/sign-up';
var loginPage = '/sign-in';
import { MdSnackBar } from '@angular/material';

@Injectable()
export class HttpService {

    tokenKey = 'token';
    userNameKey = 'userName';

    userLoggedInSubject = new Subject<boolean>();
    busyLoadingSubject = new Subject<boolean>();

    private observable = new Observable();

    constructor(
        private http: Http, 
        private storageService:StorageService, 
        private router:Router, 
        private snackBar:MdSnackBar){}

    private logInUser(){
        this.userLoggedInSubject.next(true);
    }
    private logOutUser(){
        this.userLoggedInSubject.next(false);
    }
    
    private handleError(error: Response, subj, router:Router){
        this.showLoading(this.busyLoadingSubject, false);
        if (error.status == 401){            
            subj.next(false);
            router.navigate([loginPage]);
            this.snackBar.open("Please Sign In", 'Close', {duration: 1000});
            return Observable.throw("User not authenticated.");
        }
        else{
            this.snackBar.open("Server error", 'Close', {duration: 1000});
            return Observable.throw(error.json);
        }
    }

    private showLoading(busyLoadingSubject:Subject<boolean>, value:boolean){
        busyLoadingSubject.next(value);
    }

    get(url:string){            
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.get(webApiURL + url, this.getTokenHeader)
            .do(x => {this.showLoading(this.busyLoadingSubject, false);})
            .catch(err => this.handleError(err, this.userLoggedInSubject, this.router));
    }
    
    post(url:string, body:any){
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.post(webApiURL + url, body, this.getTokenHeader)
            .do(x => {this.showLoading(this.busyLoadingSubject, false);})
            .catch(err => this.handleError(err, this.userLoggedInSubject, this.router));
    }

    signIn(userName:string, password:string){
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.post(authURL + 'signin', {userName:userName, password: password})
            .do(x => {
                var successful = x.json().requestSuccessful;
                if (successful){
                    var token = x.json().token;
                    this.saveUserInfo(userName, token);
                    this.logInUser();
                }
                else{
                    this.logOutUser();
                }
                this.showLoading(this.busyLoadingSubject, false);
            });            
    }

    signOut(){
        this.storageService.clearLocal();
        this.logOutUser();
        this.router.navigate([loginPage]);
        return this.http.get(authURL + 'signout');
    }

    getMe(){
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.get(authURL + 'me', this.getTokenHeader)
            .do(x => {this.showLoading(this.busyLoadingSubject, false);})
            .catch(err => this.handleError(err, this.userLoggedInSubject, this.router));
    }

    saveMe(me:any){
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.post(authURL + 'me', me, this.getTokenHeader)
            .do(x => {this.showLoading(this.busyLoadingSubject, false);})
            .catch(err => this.handleError(err, this.userLoggedInSubject, this.router));
    }

    signUp(user){
        this.showLoading(this.busyLoadingSubject, true);
        return this.http.post(authURL + 'signup', user)
            .do(x => {
                var successful = x.json().requestSuccessful;
                if (successful){
                    var token = x.json().token;
                    this.saveUserInfo(user.userName, token);
                    this.logInUser();
                }
                else{
                    this.logOutUser();
                }
                this.showLoading(this.busyLoadingSubject, false);
            })
            .catch(err => this.handleError(err, this.userLoggedInSubject, this.router));
    }

    private saveUserInfo(userName:string, token:string){
        this.storageService.storeLocal(this.userNameKey, userName);
        this.storageService.storeLocal(this.tokenKey, token);
    }

    private getUserName(){
        return this.storageService.getLocal(this.userNameKey);        
    }

    private getToken(){
        return this.storageService.getLocal(this.tokenKey);        
    }

    private get getTokenHeader(){
        var headers = new Headers({'Authorization': 'Bearer ' + this.getToken()});
        return new RequestOptions({headers: headers});
    }
}
