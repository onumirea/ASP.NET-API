import { TestBed } from '@angular/core/testing';

import { AllIngredienteService } from './allingrediente.service';

describe('AllingredienteService', () => {
  let service: AllIngredienteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AllIngredienteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
