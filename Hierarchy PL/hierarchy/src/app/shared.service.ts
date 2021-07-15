import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { StudentsResult } from 'models/students-result.model';
import { FacultyResult } from 'models/faculty-result.model';
import { Faculty } from 'models/faculty.model';
import { SpecialityResult } from 'models/speciality-result.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:52865/api";
  constructor(private http:HttpClient) { }

  async getStudentList():Promise<StudentsResult>{
      return await this.http.get<StudentsResult>(this.APIUrl + '/Student/GetAllStudents').toPromise();
  }
  
  async getFacultyList():Promise<FacultyResult>{
    return await this.http.get<FacultyResult>(this.APIUrl + '/Faculty/GetEachFaculty').toPromise();
  }

  async getFacultyName(val:number):Promise<Faculty>{
    return await this.http.get<Faculty>(this.APIUrl + '/Faculty/GetFacultyNameById?faculty_id='+val).toPromise();
  }

  //async getSpecialityList():Promise<SpecialityResult>{
   // return await this.http.get<SpecialityResult>(this.APIUrl + '/')
  //}

  
}
