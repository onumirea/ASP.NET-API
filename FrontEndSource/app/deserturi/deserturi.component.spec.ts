import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeserturiComponent } from './deserturi.component';

describe('DeserturiComponent', () => {
  let component: DeserturiComponent;
  let fixture: ComponentFixture<DeserturiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeserturiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeserturiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
