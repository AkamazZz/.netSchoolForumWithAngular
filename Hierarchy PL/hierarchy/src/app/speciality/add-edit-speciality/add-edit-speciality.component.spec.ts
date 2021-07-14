import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSpecialityComponent } from './add-edit-speciality.component';

describe('AddEditSpecialityComponent', () => {
  let component: AddEditSpecialityComponent;
  let fixture: ComponentFixture<AddEditSpecialityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSpecialityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSpecialityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
