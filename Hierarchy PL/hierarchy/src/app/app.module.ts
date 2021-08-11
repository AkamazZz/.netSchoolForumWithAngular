import { BrowserModule } from '@angular/platform-browser';
import { NgModule,NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentsComponent } from './students/students.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { SubjectComponent } from './subject/subject.component';
import { FacultyComponent } from './faculty/faculty.component';
import { SpecialityComponent } from './speciality/speciality.component';
import { AssessmentComponent } from './assessment/assessment.component';
import { ShowSubjectComponent } from './subject/show-subject/show-subject.component';
import { AddEditSubjectComponent } from './subject/add-edit-subject/add-edit-subject.component';
import { ShowFacultyComponent } from './faculty/show-faculty/show-faculty.component';
import { AddEditFacultyComponent } from './faculty/add-edit-faculty/add-edit-faculty.component';
import { ShowSpecialityComponent } from './speciality/show-speciality/show-speciality.component';
import { AddEditSpecialityComponent } from './speciality/add-edit-speciality/add-edit-speciality.component';
import { ShowAssessmentComponent } from './assessment/show-assessment/show-assessment.component';
import { AddEditAssessmentComponent } from './assessment/add-edit-assessment/add-edit-assessment.component';
import { ShowStudentsComponent } from './students/show-students/show-students.component';
import { AddEditStudentsComponent } from './students/add-edit-students/add-edit-students.component';
import {SharedService} from './shared.service';
import { GroupComponent } from './group/group.component';
import { ShowGroupComponent } from './group/show-group/show-group.component';
import { AddEditGroupComponent } from './group/add-edit-group/add-edit-group.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import { StudentGpaSort } from './Classes/StudentGpaSort.pipe';
import { MatTableModule } from "@angular/material/table";
  import { MatButtonModule} from "@angular/material/button";
  import { MatCheckboxModule } from "@angular/material/checkbox";
  import {  MatPaginatorModule} from "@angular/material/paginator";
  import {  MatSortModule } from "@angular/material/sort";
import { DynamicMatTableModule } from 'dynamic-mat-table';
@NgModule({
  declarations: [
    AppComponent,
    StudentsComponent,
    HomeComponent,
    SubjectComponent,
    FacultyComponent,
    SpecialityComponent,
    AssessmentComponent,
    ShowSubjectComponent,
    AddEditSubjectComponent,
    ShowFacultyComponent,
    AddEditFacultyComponent,
    ShowSpecialityComponent,
    AddEditSpecialityComponent,
    ShowAssessmentComponent,
    AddEditAssessmentComponent,
    ShowStudentsComponent,
    AddEditStudentsComponent,
    GroupComponent,
    ShowGroupComponent,
    AddEditGroupComponent,
    StudentGpaSort,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
        MatCheckboxModule,
        DynamicMatTableModule,
        MatPaginatorModule,
        MatSortModule,
    AppRoutingModule,
    MDBBootstrapModule.forRoot(),
    Ng2SearchPipeModule,
    
    RouterModule.forRoot([
      {path: 'ApplyStudent', component: AddEditStudentsComponent},
    ]),
    BrowserAnimationsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
