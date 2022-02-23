import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeluriPrincipaleComponent } from './feluri-principale.component';

describe('FeluriPrincipaleComponent', () => {
  let component: FeluriPrincipaleComponent;
  let fixture: ComponentFixture<FeluriPrincipaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeluriPrincipaleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FeluriPrincipaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
