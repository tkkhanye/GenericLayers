import 'hammerjs';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MdButtonModule, MdCheckboxModule, MdToolbarModule} from '@angular/material';
import {RouterModule} from '@angular/router';
import { MaterialModule, MdNativeDateModule } from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { HttpModule, JsonpModule } from '@angular/http';

import { StorageService } from './services/storagehandler/storage.service';
import { HttpService} from './services/httphandler/http.service';
import { AuthService} from './services/authhandler/auth.service';
import { LookupsService} from './services/lookups/lookups.service';
import { DealerService } from './feature/dealer/dealer.service';
import { PropertyService } from './feature/property/property.service';

import { AppComponent } from './app.component';
import { HomeComponent } from './feature/home/home.component';
import { SignInComponent } from './feature/account/sign-in/sign-in.component';
import { SignUpComponent } from './feature/account/sign-up/sign-up.component';
import { DealerComponent } from './feature/dealer/dealer.component';
import { DealerListComponent } from './feature/dealer/dealer-list.component';
import { FilterPipe } from './pipes/filter.pipe';
import { AddressComponent } from './feature/address/address.component';
import { ProfileComponent } from './feature/account/profile/profile.component';
import { PropertyComponent } from './feature/property/property.component';
import { PropertyListComponent } from './feature/property/property-list.component';
import { DeleteDialogComponent } from './dialogues/delete-dialog/delete-dialog.component';

var routes = [
  {
    path: '',
    component: HomeComponent
  },{
    path: 'dealer',
    component: DealerComponent
  },{
    path: 'dealer/:id',
    component: DealerComponent
  },{
    path: 'dealer-list',
    component: DealerListComponent
  },{
    path: 'property',
    component: PropertyComponent
  },{
    path: 'property/:id',
    component: PropertyComponent
  },{
    path: 'property-list',
    component: PropertyListComponent
  },{
    path: 'profile',
    component: ProfileComponent
  },{
    path: 'sign-in',
    component: SignInComponent
  },{
    path: 'sign-up',
    component: SignUpComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    HomeComponent,
    SignUpComponent,
    DealerComponent,
    DealerListComponent,
    FilterPipe,
    AddressComponent,
    ProfileComponent,
    PropertyComponent,
    PropertyListComponent,
    DeleteDialogComponent,
  ],
  imports: [
    BrowserModule,
    MdButtonModule,
    MdCheckboxModule,
    MdToolbarModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
    MaterialModule,
    MdNativeDateModule, 
    HttpModule,
    JsonpModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    StorageService,
    HttpService,
    AuthService,
    LookupsService,
    DealerService,
    PropertyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
