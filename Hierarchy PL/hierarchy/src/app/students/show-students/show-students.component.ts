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
  }

  async refreshStudentList(){
    let result = new StudentsResult();
    this.StudentList.result_set = [];
    
    await this.service.getStudentList().then((data) => {
      result.success = data.success;
      result.userMessage = data.userMessage;
      result.result_set = data.result_set;
      if (result.success) {
       this.StudentList=data;
      } else {
        alert(result.userMessage);
      }
  });
}
}

