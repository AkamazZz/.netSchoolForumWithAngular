import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-speciality',
  templateUrl: './add-edit-speciality.component.html',
  styleUrls: ['./add-edit-speciality.component.css']
})
export class AddEditSpecialityComponent implements OnInit {

  constructor(private service:SharedService) { }
  //@Input() speciality:any;
  ngOnInit(): void {
  }

}
