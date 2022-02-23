import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRetetaComponent } from './view-reteta.component';

describe('ViewRetetaComponent', () => {
  let component: ViewRetetaComponent;
  let fixture: ComponentFixture<ViewRetetaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewRetetaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewRetetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
