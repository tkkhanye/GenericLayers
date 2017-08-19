import { Injectable } from '@angular/core';
import { HttpService } from '../httphandler/http.service';

@Injectable()
export class LookupsService {

  constructor(private httpService: HttpService) { }
    private serviceUrl = "lookup/";

    getEstablishmentTypes(){
        return this.httpService.get(this.serviceUrl + "getestablishmenttypes").map(res => res.json());
    }

}
