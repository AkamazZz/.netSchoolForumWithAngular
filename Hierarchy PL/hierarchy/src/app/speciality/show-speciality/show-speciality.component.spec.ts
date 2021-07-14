import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSpecialityComponent } from './show-speciality.component';

describe('ShowSpecialityComponent', () => {
  let component: ShowSpecialityComponent;
  let fixture: ComponentFixture<ShowSpecialityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSpecialityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowSpecialityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
