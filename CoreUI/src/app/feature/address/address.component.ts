import { Component, OnInit, Input } from '@angular/core';
import { AddressModel } from '../../models/models';

@Component({
  selector: 'address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {
    @Input('model') address:AddressModel;
    @Input() title;

    constructor(){
    }

    ngOnInit(){
        this.address = this.address ? this.address : new AddressModel();
        this.title = this.title ? this.title : "Address";
    }

}
