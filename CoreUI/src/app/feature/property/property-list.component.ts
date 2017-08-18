import { Component, OnInit, Input } from '@angular/core';
import { PropertyService } from './property.service';
import { ActivatedRoute } from '@angular/router';
import { PropertyModel } from '../../models/models';


@Component({
  selector: 'property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
    @Input() filterBy:string;
    searchBy = "";
    models:PropertyModel[] = [];

    constructor(private service:PropertyService, private route:ActivatedRoute){}

    ngOnInit(){
        this.refreshList();
    }

    refreshList(){
        var response = this.service.getModels().subscribe(response => {
            this.models = response;
        });

    }
}
