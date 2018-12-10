import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JbzdyComponent } from './jbzdy.component';

describe('JbzdyComponent', () => {
  let component: JbzdyComponent;
  let fixture: ComponentFixture<JbzdyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JbzdyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JbzdyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
