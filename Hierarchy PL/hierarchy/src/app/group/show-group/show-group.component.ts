import { Component, OnInit } from '@angular/core';
import { GroupResult } from 'models/group-result.model';
import { Group } from 'models/group.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-group',
  templateUrl: './show-group.component.html',
  styleUrls: ['./show-group.component.css']
})
export class ShowGroupComponent implements OnInit {

  constructor(private service:SharedService) { }
  GroupList: GroupResult = new GroupResult();
  ngOnInit(): void {
    this.refreshGroupList();
  }
  async refreshGroupList(){
    await this.service.getGroupList().then((data) => {
      
      if (data.success) {
       this.GroupList=data;
       
    
      } else {
        alert(data.userMessage);
      }
      })
  }
}
