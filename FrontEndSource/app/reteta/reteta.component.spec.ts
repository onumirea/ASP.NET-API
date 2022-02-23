import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetetaComponent } from './reteta.component';

describe('RetetaComponent', () => {
  let component: RetetaComponent;
  let fixture: ComponentFixture<RetetaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetetaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RetetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
