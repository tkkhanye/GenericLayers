import { Injectable } from '@angular/core';

@Injectable()
export class StorageService {
    storeLocal(key, data){
        localStorage.setItem(key, data);    
    }
    getLocal(key){
        return localStorage.getItem(key);
    }

    clearLocal(){
        localStorage.clear();
    }
}
