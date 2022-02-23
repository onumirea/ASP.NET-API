import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CiorbeComponent } from './ciorbe.component';

describe('CiorbeComponent', () => {
  let component: CiorbeComponent;
  let fixture: ComponentFixture<CiorbeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CiorbeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CiorbeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
