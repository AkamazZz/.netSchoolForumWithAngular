import { Pipe, PipeTransform } from "@angular/core";
import { StudentGpa } from "models/studentgpa.model";


@Pipe({name: 'StudentGpaSort'})
export class StudentGpaSort implements PipeTransform{


  transform(arr: StudentGpa[]): StudentGpa[]{
    if(arr){
    return arr.sort((a, b) => {
      if (a.GPA> b.GPA || a.student_name < b.student_name || a.student_surname < b.student_surname) {
        return 1;
      }
      if (a.GPA < b.GPA || a.student_name > b.student_name || a.student_surname > b.student_surname) {
        return -1;
      }
      return 0;
    });
  }
  else{
    return arr;
  }
  }


}
