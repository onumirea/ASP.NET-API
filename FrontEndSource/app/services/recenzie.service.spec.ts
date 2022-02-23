import { TestBed } from '@angular/core/testing';

import { RecenzieService } from './recenzie.service';

describe('RecenzieService', () => {
  let service: RecenzieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecenzieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
