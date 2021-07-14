import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { StudentsResult } from 'models/students-result.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:52865/api";
  constructor(private http:HttpClient) { }

  async getStudentList():Promise<StudentsResult>{
      return await this.http.get<StudentsResult>(this.APIUrl + '/Student/GetAllStudents').toPromise();
  }
  
}
