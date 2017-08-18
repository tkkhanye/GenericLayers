import { TestBed, inject } from '@angular/core/testing';

import { HttpService } from './http.service';
import { HttpStub } from '../../tests/imports/http-stub';
import { RouterStub } from '../../tests/imports/router-stub';
import { MdSnackBarStub } from '../../tests/imports/md-snack-bar-stub';
import { StorageServiceStub } from '../../tests/providers/storage-service-stub';

import { Http, XHRBackend, ResponseOptions } from "@angular/http";
import { StorageService } from "app/services/storagehandler/storage.service";
import { MdSnackBar } from "@angular/material";
import { Router } from "@angular/router";
import {MockBackend, MockConnection} from '@angular/http/testing';
import { fakeAsync } from "@angular/core/testing";


describe('HttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        HttpService,
        {provide: Http, useValue: HttpStub},
        {provide: StorageService, useValue: StorageServiceStub},
        {provide: Router, useValue: RouterStub},
        {provide: MdSnackBar, useValue: MdSnackBarStub},
        {provide: XHRBackend, useClass: MockBackend }
      ]
    });
  });

  it('should be created', inject([HttpService], (service: HttpService) => {
    expect(service).toBeTruthy();
  }));

    
  it('just return anything', inject([HttpService, XHRBackend], (service: HttpService, mockBackEnd:MockBackend) => {
    const mockResponse = {
      data: [
        { id: 0, name: 'Video 0' },
        { id: 1, name: 'Video 1' },
        { id: 2, name: 'Video 2' },
        { id: 3, name: 'Video 3' },
      ]
    };

    mockBackEnd.connections.subscribe((connection) => {
      connection.mockRespond(new Response(new ResponseOptions({
          body: JSON.stringify(mockResponse)
        })));
    });

    service.get('anything').subscribe(res =>{
      expect(res).toBeTruthy();
      expect(res.length).toBe(4);
    });

  }));  

});
