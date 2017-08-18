import { Component, OnInit } from '@angular/core';
import { DealerService } from './dealer.service';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DealerModel } from '../../models/models';

@Component({
  selector: 'dealer',
  templateUrl: './dealer.component.html',
  styleUrls: ['./dealer.component.css']
})
export class DealerComponent implements OnInit {
    dealer:DealerModel = new DealerModel();
    isNewRecord = false;

    constructor(private dealerService:DealerService, private router:Router, private activatedRoute:ActivatedRoute){}

    ngOnInit(){
        if (this.activatedRoute.snapshot.params.id)
            this.getDealer(this.activatedRoute.snapshot.params.id);
        else
            this.isNewRecord = true;
    }

    private getDealer(id){
        this.dealerService.getDealer(id).subscribe(x => this.dealer = x.json());
    }

    save(){
        this.dealerService.saveDealer(this.dealer).subscribe(x => {
            this.router.navigate(['/dealer-list']);
        });
    }

}
