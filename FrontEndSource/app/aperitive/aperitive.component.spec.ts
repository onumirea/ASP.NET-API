import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AperitiveComponent } from './aperitive.component';

describe('AperitiveComponent', () => {
  let component: AperitiveComponent;
  let fixture: ComponentFixture<AperitiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AperitiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AperitiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
