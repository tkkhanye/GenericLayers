import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerListComponent } from './dealer-list.component';

describe('DealerListComponent', () => {
  let component: DealerListComponent;
  let fixture: ComponentFixture<DealerListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DealerListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DealerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
