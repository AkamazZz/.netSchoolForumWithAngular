import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
    ShowGroupComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
   /* RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'students', component: StudentsComponent},
    ])*/
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
