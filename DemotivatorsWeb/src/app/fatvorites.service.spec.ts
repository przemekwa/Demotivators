import { TestBed } from '@angular/core/testing';

import { FatvoritesService } from './fatvorites.service';

describe('FatvoritesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FatvoritesService = TestBed.get(FatvoritesService);
    expect(service).toBeTruthy();
  });
});
