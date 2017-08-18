import { Component, OnInit, Input } from '@angular/core';
import { DealerService } from './dealer.service';
import { ActivatedRoute } from '@angular/router';
import { DealerModel } from '../../models/models';

@Component({
  selector: 'dealer-list',
  templateUrl: './dealer-list.component.html',
  styleUrls: ['./dealer-list.component.css']
})
export class DealerListComponent implements OnInit {
    searchBy = '';    
    dealers:DealerModel[] = [];

    constructor(private dealerService:DealerService, private route:ActivatedRoute){}

    ngOnInit(){
        this.refreshList();    
    }

    refreshList(){
        var response = this.dealerService.getDealers().subscribe(response => {
            this.dealers = response.json();
        });

    }


}
