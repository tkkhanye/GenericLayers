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

import { AppComponent } from './app.component';
import { HomeComponent } from './feature/home/home.component';
import { SignInComponent } from './feature/account/sign-in/sign-in.component';
import { SignUpComponent } from './feature/account/sign-up/sign-up.component';
import { FilterPipe } from './pipes/filter.pipe';
import { ProfileComponent } from './feature/account/profile/profile.component';
import { DeleteDialogComponent } from './dialogues/delete-dialog/delete-dialog.component';

var routes = [
  {
    path: '',
    component: HomeComponent
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
    FilterPipe,
    ProfileComponent,
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
    LookupsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
