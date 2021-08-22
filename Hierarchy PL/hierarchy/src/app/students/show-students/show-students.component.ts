import { Component, HostListener, Input, NgIterable, OnInit , ViewChild} from '@angular/core';
import { StudentsResult } from 'models/students-result.model';
import { Students } from 'models/students.model';
import { SharedService } from 'src/app/shared.service';
import {BsModalRef, ModalDirective} from 'ngx-bootstrap/modal';
import { MDBModalService, ModalContainerComponent } from 'angular-bootstrap-md';
import { Variable } from '@angular/compiler/src/render3/r3_ast';
import {trigger, state, style, transition, animate, keyframes, useAnimation} from '@angular/animations';
import { KeyValue, KeyValuePipe } from '@angular/common';
import { StudentGpa } from 'models/studentgpa.model';
import {MatPaginator} from '@angular/material/paginator';
import { FadeInOut } from 'src/app/animations';
import {
  TableRow,
  TableField,
  PrintConfig,
  TableSetting,
  TablePagination,
  TableSelectionMode,
  DynamicMatTableComponent,
  TableVirtualScrollDataSource,
  IRowEvent
} from "dynamic-mat-table";
import { Router } from '@angular/router';
import { StudentGpaSort } from 'src/app/Classes/StudentGpaSort';


function delay(ms: number){
  return new Promise( resolve => setTimeout(resolve,ms ));
}
@Component({
  selector: 'app-show-students',
  templateUrl: './show-students.component.html',
  styleUrls: ['./show-students.component.css'],
  animations: [
    FadeInOut
  ]
})

export class ShowStudentsComponent implements OnInit {
  @HostListener('keydown.escape')
fn() {
  if(this.ActivateAddStudentComp == true || this.ActivateEditStudentComp == true || this.ActivateShowSubjectComp)
  this.ActivateAddStudentComp=false;
      this.ActivateEditStudentComp = false;
      this.ActivateShowSubjectComp = false;
 this.refreshStudentList();
}
  StudentGpaColumns: string[] = ['student_id', 'student_name', 'student_surname', 'GPA'];


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(DynamicMatTableComponent, { static: true })
  table!: DynamicMatTableComponent<TestElement>;

 
  @ViewChild('Modal', {static: true}) Modal: ModalDirective;

  @Input() isChanged: Boolean;
  constructor(private service:SharedService, private ModalService: MDBModalService, private router: Router) {
   }
   IsSimpleList: Boolean;
   IsTopList: Boolean;
   GpaStudents: StudentGpa[]=[];
  dataSource = new TableVirtualScrollDataSource(this.GpaStudents);

  StudentList:StudentsResult = new StudentsResult();
  StudentListWithoutFilter: StudentsResult = new StudentsResult();
  SortElements = ['student_id', 'student_name', 'student_surname', 'faculty_name', 'speciality_name', 'group_name'];
  ngOnInit(): void {
    if(localStorage.length>0){
    this.IsSimpleList = localStorage.getItem('IsSimpleList') == "true";
    this.IsTopList = localStorage.getItem('IsTopList') == "true"
    }
    this.refreshStudentList();
  }

  ModalTitle: string;
  isLoaded: boolean = false;
 async refreshStudentList(){

if(this.IsSimpleList){
await this.service.getStudentList().then((data) => {
      
      if (data.success) {
       this.StudentList=data;    
      } else{
        alert(data.userMessage);
      }
  });
}
else if (this.IsTopList){
  await this.service.GetTopStudents().then((data) => {
      
    if (data.success) {
     this.StudentList.result_set_dictionary=data.result_set_dictionary;
     if(this.GpaStudents.length != 0){
       this.GpaStudents.splice(0);
     }
     this.getEntries();
     this.dataSource.data = this.GpaStudents;
     this.dataSource.paginator = this.paginator;


    } else {
      alert(data.userMessage);
    }
});


}
}
filtersLoaded: Promise<boolean>;
gpaSort(arr: StudentGpa[]): StudentGpa[]{
  if(arr){
  return arr.sort((a, b) => {
    if (a.GPA> b.GPA || a.student_name > b.student_name || a.student_surname >   b.student_surname) {
      return 1;
    }
    if (a.GPA < b.GPA || a.student_name <b.student_name || a.student_surname < b.student_surname) {
      return -1;
    }
    return 0;
  });
}
else{
  return arr;
}
}

getEntries(){
  
  for(let [key,value] of Object.entries(this.StudentList.result_set_dictionary)){
    this.service.InfoById(Number(key)).subscribe((d) =>{
      let student: StudentGpa = {
        student_id: Number(key),
        student_name: d.result_set.student_name,
        student_surname: d.result_set.student_surname,
        GPA: Number(value)
      }
     this.GpaStudents.push(student);

      })
    }
    this.GpaStudents = this.gpaSort(this.GpaStudents);

}
async infoById(id:number){
    this.service.InfoById(id).subscribe((data) =>{
      this.StudentList.result_set.push(data.result_set); })

}
sortTop = (a:any,b:any) =>{
  return 1;
}
ActivateAddStudentComp:Boolean=false;
ActivateEditStudentComp:Boolean=false;
student:Students = new Students();
modalRef:BsModalRef;
GPA_filter:string = "";
student_id_filter:string="";
student_name_filter:string="";
student_surname_filter:string="";
student_faculty_filter:string="";
student_speciality_filter:string="";
student_group_filter:string="";

async filter(){
  var student_id_filter = this.student_id_filter;
  var student_name_filter = this.student_name_filter;
  var student_surname_filter = this.student_surname_filter;
  var student_faculty_filter = this.student_faculty_filter;
  var student_speciality_filter = this.student_speciality_filter;
  var student_group_filter = this.student_group_filter;
  this.StudentList.result_set =  await this.StudentListWithoutFilter.result_set.filter(function (sort){
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
    this.ActivateShowSubjectComp = false;
   
}
delete_student(student_id: number){
  if(confirm('Are you sure?')){
    let result = new StudentsResult();
    this.service
    .DeleteStudent(student_id)
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
studentSubject: Students = new Students();
ActivateShowSubjectComp: boolean = false;
showSubjects(student: Students){
  this.studentSubject = student;
  this.ActivateShowSubjectComp = true;
  this.ModalTitle = student.student_name + " " +student.student_surname + "'s subject profile";
  this.Modal.show();
}
topStudents(){
  this.IsSimpleList = false;
  this.IsTopList = true;
  localStorage.setItem("IsSimpleList", JSON.stringify(this.IsSimpleList));
  localStorage.setItem("IsTopList", JSON.stringify(this.IsTopList));
  this.refreshStudentList();
}
simpleStudentInformation(){
  this.IsSimpleList = true;
  this.IsTopList = false;
  localStorage.setItem("IsSimpleList", JSON.stringify(this.IsSimpleList));
  localStorage.setItem("IsTopList", JSON.stringify(this.IsTopList));
  this.refreshStudentList();
  
}

}

export interface TestElement extends TableRow {
  student_id: number;
  student_name: string;
  student_surname: string;
  GPA: number;
}

