import { Component, Directive, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Students } from 'models/students.model';
import { SubjectsResult } from 'models/subjects-result.model';
import { SharedService } from 'src/app/shared.service';
import { FadeInOut } from 'src/app/animations';
import { Assessment } from 'models/assessment.model';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Subject } from 'models/subject.model';
import { StudentSubject } from 'models/student-subject.model';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-show-subject',
  templateUrl: './show-subject.component.html',
  styleUrls: ['./show-subject.component.css'],
  animations: [
    FadeInOut,
  ]
})

export class ShowSubjectComponent implements OnInit {
  @Output() onCreate: EventEmitter<any> = new EventEmitter<any>();
  @Input() studentSubject: Students = new Students();
  @Input() ActivateShowSubjectComp: boolean;
  StudentSubjectList: SubjectsResult = new SubjectsResult();
  SubjectListToAdd: SubjectsResult = new SubjectsResult();
  SubjectToAdd:StudentSubject = new StudentSubject();
  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.onCreate.emit(null); 
    this.RefreshSubjects();
    this.RefreshSubjectListByStudent();
    this.RefreshAssessmentList();
  }
  AssessmentList: Assessment[]=[];

  async RefreshAssessmentList(){
    await this.service.GetGradeByStudent(this.studentSubject.student_id).then((data)=>{
      if(data.success){
        this.AssessmentList = data.result_set;
      }
      
    })
    .catch((error) => {
      alert(
        error.error.userMessage +
          'Student does not have assessments'
      );
    });
  }
  async RefreshSubjectListByStudent(){
     await this.service.GetSubjectByStudent(this.studentSubject.student_id).then((data)=> {
      
        if (data.success) {
         this.StudentSubjectList = data;
        if(data.result_set.length == 0){

        }
    
        } else {
          alert(data.userMessage);
        }
      })
  }
 async deleteSubjectOfStudent(student_id: number, subject_id:number){
    if(confirm('Are you sure?')){
      let result = new SubjectsResult();
    await this.service
      .DeleteSubjectOfStudent(student_id, subject_id)
      .then((data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        if (result.success) {
          alert('You have successfully deleted subject');
          this.RefreshSubjectListByStudent();
        } 
       
      })
      .catch((error) => {
        alert(
          error.error.userMessage +
            'Student does not have this subject'
        );
      });
    }
  }
  
  async createGrade(grade:Assessment){
    await this.service.CreateGrade(grade).then((data)=>{
      if(data.success){
        alert('grade has been created as ');
        this.RefreshAssessmentList();

      }
      alert('grade had been created before ');
    })
    .catch((error) => {
      alert(
        error.error.userMessage +
          'There is no such subject or grade'
      );
    })
  }
  async RefreshSubjects(){
    await this.service.GetSubjects().then((data)=> {
      if(data.success){
        this.SubjectListToAdd = data;
      }
    })
    .catch((error) => {
      alert(
        error.error.userMessage +
          'There is no such subject or grade'
      );
    })
  
  }
  ngAfterViewInit() {
  this.RefreshSubjectListByStudent() }
  async AddSubjectTOStudent(add:StudentSubject){
    add.student_id =this.studentSubject.student_id;
    await this.service.AddSubjectToStudent(add).then((data)=>{
      if(data.success && data.result_set != null){
        alert('The subject has been added');
        this.RefreshAssessmentList();
        this.RefreshSubjectListByStudent();
      }else{
      alert('grade had been created before ');
      }
    })
    .catch((error) => {
      alert(
        error.error.userMessage 
      );
    })
  }
}

