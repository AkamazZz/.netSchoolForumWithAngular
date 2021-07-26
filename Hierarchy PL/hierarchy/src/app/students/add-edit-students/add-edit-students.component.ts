import { Component, Input, OnInit } from '@angular/core';
import { FacultyResult } from 'models/faculty-result.model';
import { Faculty } from 'models/faculty.model';
import { GroupResult } from 'models/group-result.model';
import { Group } from 'models/group.model';
import { SpecialityResult } from 'models/speciality-result.model';
import { StudentsResult } from 'models/students-result.model';
import { Students } from 'models/students.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-students',
  templateUrl: './add-edit-students.component.html',
  styleUrls: ['./add-edit-students.component.css']
})
export class AddEditStudentsComponent implements OnInit {
  currentStudent: Students = new Students();
  load: string = 'no-show';
  disabled: string = '';
  @Input() student:Students= new Students();
  constructor(private service:SharedService) { }

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
  async SubmitApplication() {
    let result = new StudentsResult();
    this.disabled = 'disabled';
    this.load = '';
    await this.service
      .AddStudent(this.currentStudent)
      .then((data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        let id = data.result_set[0].student_id;
        if (result.success) {
          alert('Your reference code is: application' + id);
        } else {
          alert(result.userMessage);
        }
        this.CurrentStudent = new Students();
      })
      .catch((error) => {
        alert(
          error.error.userMessage +
            ' Please make sure you have provided all the values'
        );
      });
    this.disabled = '';
    this.load = 'no-show';
  }
}
  

