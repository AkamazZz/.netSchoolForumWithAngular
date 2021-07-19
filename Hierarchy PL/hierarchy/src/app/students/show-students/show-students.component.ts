import { Component, OnInit } from '@angular/core';
import { StudentsResult } from 'models/students-result.model';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-show-students',
  templateUrl: './show-students.component.html',
  styleUrls: ['./show-students.component.css']
})
export class ShowStudentsComponent implements OnInit {

  constructor(private service:SharedService) { }

  StudentList:StudentsResult= new StudentsResult();
  ngOnInit(): void {
    this.refreshStudentList();
    
  }
  
  
 async refreshStudentList(){

    
await this.service.getStudentList().then((data) => {
      
      if (data.success) {
       this.StudentList=data;
       
    
      } else {
        alert(data.userMessage);
      }
  });
  
  
  
}


}


