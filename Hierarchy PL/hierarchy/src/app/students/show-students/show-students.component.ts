import { Component, OnInit } from '@angular/core';
import { StudentsResult } from 'models/students-result.model';
import { SharedService } from 'src/app/shared.service';
import { FacultyResult } from 'models/faculty-result.model';
import { Faculty } from 'models/faculty.model';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-show-students',
  templateUrl: './show-students.component.html',
  styleUrls: ['./show-students.component.css']
})
export class ShowStudentsComponent implements OnInit {

  constructor(private service:SharedService) { }

  StudentList:StudentsResult= new StudentsResult();
  facultyNames: Faculty = new Faculty();
  ngOnInit(): void {
    this.refreshStudentList();
    
  }
  
  
 async refreshStudentList(){

    this.StudentList.result_set = [];
    
await this.service.getStudentList().then((data) => {
      
      if (data.success) {
       this.StudentList=data;
       for(let k=0; k<data.result_set.length;++k ){
        this.service.getFacultyName(data.result_set[k].faculty_id).then((faculty) =>{
      this.StudentList.result_set[k].faculty_name = faculty.faculty_name;
      });
    }
      } else {
        alert(data.userMessage);
      }
  });
  
  
  
}
}


