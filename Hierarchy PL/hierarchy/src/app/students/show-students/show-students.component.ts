import { Component, Input, OnInit , ViewChild} from '@angular/core';
import { StudentsResult } from 'models/students-result.model';
import { Students } from 'models/students.model';
import { SharedService } from 'src/app/shared.service';
import {BsModalRef, ModalDirective} from 'ngx-bootstrap/modal';
import { MDBModalService, ModalContainerComponent } from 'angular-bootstrap-md';
import { Variable } from '@angular/compiler/src/render3/r3_ast';


function delay(ms: number){
  return new Promise( resolve => setTimeout(resolve,ms ));
}
@Component({
  selector: 'app-show-students',
  templateUrl: './show-students.component.html',
  styleUrls: ['./show-students.component.css']
})

export class ShowStudentsComponent implements OnInit {
  @ViewChild('Modal', {static: true}) Modal: ModalDirective;

  @Input() isChanged: Boolean;
  constructor(private service:SharedService, private ModalService: MDBModalService) {
   }

  StudentList:StudentsResult= new StudentsResult();
  StudentListWithoutFilter: StudentsResult = new StudentsResult();
  SortElements = ['student_id'];
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
ActivateAddStudentComp:Boolean=false;
ActivateEditStudentComp:Boolean=false;
student:Students = new Students();
modalRef:BsModalRef;
student_id_filter:string="";
student_name_filter:string="";
student_surname_filter:string="";
student_faculty_filter:string="";
student_speciality_filter:string="";
student_group_filter:string="";

filter(){
  var student_id_filter = this.student_id_filter;
  var student_name_filter = this.student_name_filter;
  var student_surname_filter = this.student_surname_filter;
  var student_faculty_filter = this.student_faculty_filter;
  var student_speciality_filter = this.student_speciality_filter;
  var student_group_filter = this.student_group_filter;
  this.StudentList.result_set = this.StudentListWithoutFilter.result_set.filter(function (sort){
      return sort.student_id.toString().toLowerCase().includes(
      student_id_filter.toString().trim().toLowerCase())
       &&
      sort.student_name.toString().toLowerCase().includes(
        student_name_filter.toString().trim().toLowerCase()) &&

      sort.student_surname.toString().toLowerCase().includes(
        student_surname_filter.toString().trim().toLowerCase())&&

      sort.faculty_id.toString().toLowerCase().includes(
        student_faculty_filter.toString().trim().toLowerCase())&&

      sort.speciality_id.toString().toLowerCase().includes(
        student_speciality_filter.toString().trim().toLowerCase())&&

      sort.faculty_id.toString().toLowerCase().includes(
        student_faculty_filter.toString().trim().toLowerCase()) &&

        sort.group_id.toString().toLowerCase().includes(
          student_group_filter.toString().trim().toLowerCase())
  });
}
sort_result(property: any, isAscending : Boolean){
  
}
show_add(){
  this.ModalTitle="Apply a new student";
  this.ActivateAddStudentComp=true;
  this.Modal.show();
}
close(){
  this.Modal.hide();
   this.refreshStudentList();
      this.ActivateAddStudentComp=false;
      this.ActivateEditStudentComp = false;
    
   
}
delete_student(student: Students){
  if(confirm('Are you sure?')){
    let result = new StudentsResult();
    this.service
    .DeleteStudent(student.student_id)
    .then((data) => {
      result.success = data.success;
      result.userMessage = data.userMessage;
      if (result.success) {
        alert('You have successfully deleted student');
      } 
      this.refreshStudentList();
      this.student = new Students();
    })
    .catch((error) => {
      alert(
        error.error.userMessage +
          'Student does not exist'
      );
    });
  }
}
show_edit(item:Students){
  this.student = item;
  this.ModalTitle="Edit student";
  this.ActivateEditStudentComp = true;
  this.Modal.show();

}
}


