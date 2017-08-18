import { PropertyModel } from '../../models/models';
import { Component, OnInit } from '@angular/core';
import { PropertyService } from './property.service';
import { Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DeleteDialogComponent } from '../../dialogues/delete-dialog/delete-dialog.component';
import {MdDialog} from '@angular/material';

@Component({
  selector: 'property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {
    model:PropertyModel = new PropertyModel();
    isNewRecord = false;

    constructor(
        private service:PropertyService, 
        private router:Router, 
        private activatedRoute:ActivatedRoute,
        private deleteDialog:MdDialog
        ){}

    ngOnInit(){
        if (this.activatedRoute.snapshot.params.id)
            this.getModel(this.activatedRoute.snapshot.params.id);
        else 
            this.isNewRecord = true;
    }

    private getModel(id){
        this.service.getModel(id).subscribe(x => this.model = x);
    }

    save(){
        this.service.save(this.model).subscribe(x => {
            this.router.navigate(['/property-list']);
        });
    }

    deleteConfirmation(){
        let response = this.deleteDialog.open(DeleteDialogComponent);
        response.afterClosed().subscribe(x => {
            console.log(x);
        });
    }

}
