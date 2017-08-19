import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataconferenceComponent } from './dataconference.component';

describe('DataconferenceComponent', () => {
  let component: DataconferenceComponent;
  let fixture: ComponentFixture<DataconferenceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataconferenceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataconferenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
