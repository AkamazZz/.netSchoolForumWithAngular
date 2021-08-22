import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { FacultyResult } from 'models/faculty-result.model';
import { Faculty } from 'models/faculty.model';
import { GroupResult } from 'models/group-result.model';
import { Group } from 'models/group.model';
import { SpecialityResult } from 'models/speciality-result.model';
import { StudentsResult } from 'models/students-result.model';
import { Students } from 'models/students.model';
import { ModalContainerComponent, ModalDirective } from 'ngx-bootstrap/modal';
import { FadeInOut } from 'src/app/animations';
import { SharedService } from 'src/app/shared.service';
import { ShowStudentsComponent } from '../show-students/show-students.component';


@Component({
  selector: 'app-add-edit-students',
  templateUrl: './add-edit-students.component.html',
  styleUrls: ['./add-edit-students.component.css'],
  animations: [
    FadeInOut
  ]

})
export class AddEditStudentsComponent  implements OnInit {
  
  currentStudent: Students = new Students();
  showStudent:ShowStudentsComponent;
  load: string = 'visibility:hidden';
  disabled: string = '';
  @Input() student:Students= new Students();
  @Input() ActivateAddStudentComp:Boolean;
  @Input() ActivateEditStudentComp:Boolean;
  isChanged: Boolean = false;
   constructor(private service:SharedService) {
     
    }

  ngOnInit(): void {
    this.refreshGroupList();
    this.RefreshSpecialityList();
    this.RefreshFacultyList();
  }
  FacultyList: FacultyResult = new FacultyResult();
  async RefreshFacultyList(){
    await this.service.getFacultyList().then((data) =>{
      if (data.success) {
        this.FacultyList=data;
        
     
       } else {
         alert(data.userMessage);
       }
    })
  }
  SpecialityList: SpecialityResult = new SpecialityResult();
  async RefreshSpecialityList(){

    await this.service.getSpecialityList().then((data) => {
        
      if (data.success) {
       this.SpecialityList=data;
       
    
      } else {
        alert(data.userMessage);
      }
  });
    }
  GroupList: GroupResult = new GroupResult();
  async refreshGroupList(){
    await this.service.getGroupList().then((data) => {
      
      if (data.success) {
       this.GroupList=data;
    
      } else {
        alert(data.userMessage);
      }
      })
  }
CurrentStudent: Students;
  async SubmitStudent() {
    let result = new StudentsResult();
    this.disabled = 'disabled';
    this.load = '';
    await this.service
      .AddStudent(this.currentStudent)
      .then((data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        if (result.success) {
          alert('We have added a new student to database');
          this.isChanged = true;
        } else {
          alert(result.userMessage);
        }
      
        
        this.CurrentStudent = new Students();
      })
      .catch((error) => {
        alert(
            ' Please make sure you have provided all the values'
        );
      });
    this.disabled = '';
    this.load = "visibility:hidden";
  }

  async UpdateStudent() {
    let result = new StudentsResult();
    this.disabled = 'disabled';
    this.load = "";
   
     this.service
      .UpdateStudent(this.student)
      .then((data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
  
        if (result.success) {
          alert('Reference code is: ' + this.student.student_id);
          this.isChanged = true;
        } else {
          alert(result.userMessage);
        }
      
        this.student = new Students();
        this.showStudent.close();
      })
      .catch((error) => {
        alert(
          error.error.userMessage +
            ' Please make sure you have provided all the values'
        );
      });
    this.disabled = '';
    this.load = "'visibility:hidden'";
    
  }
}
  

