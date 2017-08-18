import {Injectable} from '@angular/core';
import {HttpService} from '../httphandler/http.service';
import {StorageService} from '../storagehandler/storage.service';
import { UserModel } from '../../models/models';
import {Router} from '@angular/router';

@Injectable()
export class AuthService{
    private url:string = 'auth/';

    constructor(private httpService:HttpService, private storageService:StorageService, private router:Router){}

    userLoggedInSubject = this.httpService.userLoggedInSubject;

    signUp(user){
        return this.httpService.signUp(user);
    }

    signIn(userName:string, password:string){
        return this.httpService.signIn(userName, password).map(res => res.json());
    }

    signOut(){
        return this.httpService.signOut();
    }

    isLoggedIn(){
        var token = this.storageService.getLocal(this.httpService.tokenKey);
        return token && true;
    }

    getUsername(){
        return this.storageService.getLocal(this.httpService.userNameKey);
    }

    getMe(){
        return this.httpService.getMe();
    }

    saveMe(user:UserModel){
        return this.httpService.saveMe(user);
    }
}