import { Injectable } from '@angular/core';
import { HttpService} from '../../services/httphandler/http.service';
import { PropertyModel} from '../..//models/models';

@Injectable()
export class PropertyService {
    constructor(private httpService:HttpService){}

    private serviceUrl = "property";

    getModel(id:string){
        return this.httpService.get(this.serviceUrl + "/" + id).map(x => x.json());
    }

    getModels(){
        return this.httpService.get(this.serviceUrl).map(x => x.json());
    }

    save(model:PropertyModel){
        return this.httpService.post(this.serviceUrl, model);
    }
}
