import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { StudentsResult } from 'models/students-result.model';
import { FacultyResult } from 'models/faculty-result.model';
import { Faculty } from 'models/faculty.model';
import { SpecialityResult } from 'models/speciality-result.model';
import { GroupResult } from 'models/group-result.model';
import { Students } from 'models/students.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { StudentResult } from 'models/student-result.model';
import { SubjectsResult } from 'models/subjects-result.model';
import { Assessment } from 'models/assessment.model';
import { AssessmentResult } from 'models/assessment-result.model';
import { AssessmentsResult } from 'models/assessments-result.model';
import { StudentSubject } from 'models/student-subject.model';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:52865/api";
  constructor(private http:HttpClient) { }
  
  modal: BsModalService;
  async getStudentList():Promise<StudentsResult>{
      return await this.http.get<StudentsResult>(this.APIUrl + '/Student/GetAllStudents').toPromise();
  }
  
  async getFacultyList():Promise<FacultyResult>{
    return await this.http.get<FacultyResult>(this.APIUrl + '/Faculty/GetEachFaculty').toPromise();
  }

  async getFacultyName(val:number):Promise<FacultyResult>{
    return await this.http.get<FacultyResult>( '/Faculty/GetFacultyNameById?faculty_id=' + val).toPromise();
  }

  async getSpecialityList():Promise<SpecialityResult>{
    return await this.http.get<SpecialityResult>(this.APIUrl + '/Speciality/GetEachSpeciality').toPromise();
  }
  async getGroupList():Promise<GroupResult>{
    return await this.http.get<GroupResult>(this.APIUrl + '/Group/GetEachGroup').toPromise();
  }
  async AddStudent(student:Students):Promise<StudentsResult>{
    return await this.http.post<StudentsResult>(this.APIUrl + '/Student/AddStudent', student, {}).toPromise();
  }
  async UpdateStudent(student:Students):Promise<StudentsResult>{
    return await this.http.put<StudentsResult>(this.APIUrl+'/Student/UpdateStudent', student).toPromise();
  }
  async DeleteStudent(student_id:number):Promise<StudentsResult>{
    return await this.http.delete<StudentsResult>(this.APIUrl+'/Student/DeleteStudent?student_id=' + student_id).toPromise();
  }
  async GetTopStudents():Promise<StudentsResult>{
    return await this.http.get<StudentsResult>(this.APIUrl + '/Student/GetTopByGPA').toPromise();
  }
   InfoById(id:number):Observable<StudentResult>{
    return this.http.get<StudentResult>(this.APIUrl + '/Student/GetWholeInfoAboutStudentById?id=' + id);
  }
  async GetSubjectByStudent(id:number):Promise<SubjectsResult>{
    return await this.http.get<SubjectsResult>(this.APIUrl + '/Subject/GetSubjectsNameByStudentId?student_id=' + id).toPromise();
  }
  async DeleteSubjectOfStudent(student_id:number, subject_id:number):Promise<SubjectsResult>{
    return await this.http.delete<SubjectsResult>(this.APIUrl + '/Subject/DeleteSubjectOfStudent?student_id=' + student_id + '&subject_id=' + subject_id).toPromise();
  }
  async GetGradeBySubjectAndStudent(student_id:number, subject_id:number):Promise<AssessmentResult>{
    return await this.http.get<AssessmentResult>(this.APIUrl + '/Assessment/GetGradeByStudentIdAndSubjectId?student_id=' + student_id + '&subject_id=' + subject_id).toPromise();
  }
  async GetGradeByStudent(student_id:number):Promise<AssessmentsResult>{
    return await this.http.get<AssessmentsResult>(this.APIUrl + '/Assessment/GetGradeByStudentId?student_id=' + student_id).toPromise();
  }
  async CreateGrade(grade: Assessment):Promise<AssessmentResult>{
    return await this.http.post<AssessmentResult>(this.APIUrl + '/Assessment/CreateGrade', grade, {}).toPromise();
  }
  async GetSubjects():Promise<SubjectsResult>{
    return await this.http.get<SubjectsResult>(this.APIUrl + '/Subject/GetSubjects').toPromise();
  }
  async AddSubjectToStudent(add:StudentSubject):Promise<SubjectsResult>{
    return await this.http.post<SubjectsResult>(this.APIUrl + '/Subject/AddSubjectToStudent', add, {}).toPromise();
  }
}
