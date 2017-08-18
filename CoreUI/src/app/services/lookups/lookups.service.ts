import { Injectable } from '@angular/core';
import { HttpService } from '../httphandler/http.service';

@Injectable()
export class LookupsService {

  constructor(private httpService: HttpService) { }
    private serviceUrl = "lookup/";

    getEstablishmentTypes(){
        return this.httpService.get(this.serviceUrl + "getestablishmenttypes").map(res => res.json());
    }
    
    getVehicleManufacturers(){
        return this.httpService.get(this.serviceUrl + 'getVehicleManufacturers').map(x => x.json());
    }
    
    getVehicleMakes(vehicleManufacturerId:number){
        return this.httpService.get(this.serviceUrl + 'GetVehicleMakes/' + vehicleManufacturerId).map(x => x.json());
    }
    
    getVehicleModels(vehicleMakeId:number){
        return this.httpService.get(this.serviceUrl + 'GetVehicleModels/' + vehicleMakeId).map(x => x.json());
    }
    
    getProductTypes(){
        return this.httpService.get(this.serviceUrl + 'GetAllProductTypes').map(x => x.json());
    }

}
