import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {StudentsComponent} from './students/students.component';
import {SubjectComponent} from './subject/subject.component';
import {FacultyComponent} from './faculty/faculty.component';
import {SpecialityComponent} from './speciality/speciality.component';
import {AssessmentComponent} from './assessment/assessment.component';
import {GroupComponent} from './group/group.component';

const routes: Routes = [
  {path: 'students', component:StudentsComponent},
  {path: 'subject', component:SubjectComponent},
  {path: 'faculty', component:FacultyComponent},
  {path: 'speciality', component: SpecialityComponent},
  {path: 'assessment', component: AssessmentComponent},
  {path: 'group', component: GroupComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
