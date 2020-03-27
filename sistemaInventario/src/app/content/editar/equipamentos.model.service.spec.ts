import { TestBed } from '@angular/core/testing';

import { EquipamentosModel} from './equipamentos.model';

describe('Equipamentos.ModelService', () => {
  let service: EquipamentosModel;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EquipamentosModel);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
