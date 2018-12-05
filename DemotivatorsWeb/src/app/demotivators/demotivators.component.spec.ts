import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemotivatorsComponent } from './demotivators.component';

describe('DemotivatorsComponent', () => {
  let component: DemotivatorsComponent;
  let fixture: ComponentFixture<DemotivatorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemotivatorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemotivatorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
