import { Component, OnInit, ViewChild} from '@angular/core';
import { SpecialityResult } from 'models/speciality-result.model';
import { Speciality } from 'models/speciality.model';
import { SharedService } from 'src/app/shared.service';
import { NgModule } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';
import { FadeInOut } from 'src/app/animations';
@Component({
  selector: 'app-show-speciality',
  templateUrl: './show-speciality.component.html',
  animations: [
    FadeInOut
  ],
  styleUrls: ['./show-speciality.component.css']
})
export class ShowSpecialityComponent implements OnInit {
  @ViewChild('Modal', {static: true}) Modal: ModalDirective;
  constructor(private service:SharedService) { }
  SpecialityList: SpecialityResult = new SpecialityResult();
  ngOnInit(): void {
    this.RefreshSpecialityList();   
  }
  
  ModalTitle:string;
  ActivateAddSpecialityComp:Boolean=false;
  ActivateEditSpecialityComp:Boolean=false;
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
    this.ModalTitle="Add Speciality";
    this.Modal.show();
    this.ActivateAddSpecialityComp=true;

  }
  EditClick(spec: Speciality){
    this.speciality = spec;
    this.ModalTitle="Change Speciality";
    this.Modal.show();
    this.ActivateEditSpecialityComp=true;
  }
  closeClick(){
    this.ActivateAddSpecialityComp=false;
    this.ActivateEditSpecialityComp=false;
    this.Modal.hide();
    this.RefreshSpecialityList();
  }
  DeleteSpeciality(spec: Speciality){
    if(confirm('Are you sure?')){
      let result = new SpecialityResult();
      
    }
  }
  
  
}
