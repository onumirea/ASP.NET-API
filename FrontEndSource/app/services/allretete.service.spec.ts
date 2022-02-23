import { TestBed } from '@angular/core/testing';

import { AllreteteService } from './allretete.service';

describe('AllreteteService', () => {
  let service: AllreteteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AllreteteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
