import { Component, OnInit } from '@angular/core';
import { SpecialityResult } from 'models/speciality-result.model';
import { Speciality } from 'models/speciality.model';
import { SharedService } from 'src/app/shared.service';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-show-speciality',
  templateUrl: './show-speciality.component.html',
  styleUrls: ['./show-speciality.component.css']
})
export class ShowSpecialityComponent implements OnInit {
  
  constructor(private service:SharedService) { }
  SpecialityList: SpecialityResult = new SpecialityResult();
  ngOnInit(): void {
    this.RefreshSpecialityList();   
  }
  
  ModalTitle:string;
  ActivateAddEditSpecialityComp:boolean=false;
  speciality:Speciality= new Speciality();
  async RefreshSpecialityList(){

  await this.service.getSpecialityList().then((data) => {
      
    if (data.success) {
     this.SpecialityList=data;
     
  
    } else {
      alert(data.userMessage);
    }
});
  }
  addClick(){
    this.speciality={
      speciality_id:0,
      faculty_id:0,
      speciality_name:""
    }
    this.ModalTitle="Add Speciality";
    this.ActivateAddEditSpecialityComp=true;
  }
  closeClick(){
    this.ActivateAddEditSpecialityComp=false;
    this.RefreshSpecialityList();
  }
}
