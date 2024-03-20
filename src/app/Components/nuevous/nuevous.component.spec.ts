import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevousComponent } from './nuevous.component';

describe('NuevousComponent', () => {
  let component: NuevousComponent;
  let fixture: ComponentFixture<NuevousComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NuevousComponent]
    });
    fixture = TestBed.createComponent(NuevousComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
