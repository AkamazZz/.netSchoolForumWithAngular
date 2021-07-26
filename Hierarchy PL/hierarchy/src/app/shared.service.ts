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
  async AddStudent(student:Students):Promise<any>{
    return await this.http.post<any>(this.APIUrl + '/Student/AddStudent', student, {}).toPromise();
    
  }
}
