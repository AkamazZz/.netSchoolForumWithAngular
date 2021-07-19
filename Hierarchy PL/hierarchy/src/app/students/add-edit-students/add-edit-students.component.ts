import { Component, OnInit } from '@angular/core';
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

  constructor(private service:SharedService) { }

  ngOnInit(): void {
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
  

