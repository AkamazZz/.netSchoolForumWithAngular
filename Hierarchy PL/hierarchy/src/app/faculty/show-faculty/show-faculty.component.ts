import { Component, OnInit } from '@angular/core';
import { FacultyResult } from 'models/faculty-result.model';
import { FadeInOut } from 'src/app/animations';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-faculty',
  templateUrl: './show-faculty.component.html',
  animations:[
    FadeInOut
  ], 
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
