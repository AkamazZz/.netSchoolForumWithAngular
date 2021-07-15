import { Component, OnInit } from '@angular/core';
import { FacultyResult } from 'models/faculty-result.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-faculty',
  templateUrl: './show-faculty.component.html',
  styleUrls: ['./show-faculty.component.css']
})
export class ShowFacultyComponent implements OnInit {

  constructor(private service:SharedService) { }
  FacultyList: FacultyResult = new FacultyResult();

  ngOnInit(): void {
    this.RefreshFacultyList();
  }


  async RefreshFacultyList(){
  this.FacultyList.result_set = [];
    
  await this.service.getFacultyList().then((data) => {
    
    if (data.success) {
     this.FacultyList=data;
    } else {
      alert(data.userMessage);
    }
});
}
}
