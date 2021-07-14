import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAssessmentComponent } from './add-edit-assessment.component';

describe('AddEditAssessmentComponent', () => {
  let component: AddEditAssessmentComponent;
  let fixture: ComponentFixture<AddEditAssessmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAssessmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
