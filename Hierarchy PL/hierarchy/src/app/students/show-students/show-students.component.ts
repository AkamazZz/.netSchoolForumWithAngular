import { Component, OnInit , TemplateRef} from '@angular/core';
import { StudentsResult } from 'models/students-result.model';
import { Students } from 'models/students.model';
import { SharedService } from 'src/app/shared.service';
import {BsModalRef} from 'ngx-bootstrap/modal';



declare var $: any;
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
  
  ModalTitle: string;
 async refreshStudentList(){

    
await this.service.getStudentList().then((data) => {
      
      if (data.success) {
       this.StudentList=data;
       
    
      } else {
        alert(data.userMessage);
      }
  });
  
  
  
}
ActivateAddStudentComp:boolean=false;
ActivateEditStudentComp:Boolean=false;
student:Students = new Students();
modalRef:BsModalRef;



show_add(){
  this.ModalTitle="Apply a new student";
  this.ActivateAddStudentComp=true;
}
close(){
  this.ActivateAddStudentComp=false;
  this.ActivateEditStudentComp = false;
  this.refreshStudentList();
}
show_edit(item:Students){
  this.student = item;
  this.ModalTitle="Edit student";
  this.ActivateEditStudentComp = true;


}
}


