import { HttpService } from '../../services/httphandler/http.service';
import { DealerModel } from '../../models/models';
import {Injectable } from '@angular/core';

@Injectable()
export class DealerService {
    private serviceUrl = 'dealer';

    constructor(private httpService:HttpService){}
    
    getDealers(){
        return this.httpService.get(this.serviceUrl);
    }

    addDealer(dealer:DealerModel){
        return this.httpService.post(this.serviceUrl, dealer);
    }

    saveDealer(dealer:DealerModel){
        return this.httpService.post(this.serviceUrl, dealer);
    }
    
    getDealer(id){
        return this.httpService.get(this.serviceUrl + "/" + id);
    }

}
