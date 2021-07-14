﻿using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hierarchy.Controllers
{

    public class AssessmentController
    {
        private IAssessment_Service _assessment_Service = new Assessment_Service();


        public async void UpdateGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id)
        {
            var result = await _assessment_Service.SetGradeByStudentIdAndSubjectId(grade, student_id, subject_id);
            if(result)
            {
                System.Console.WriteLine("The grade has been changed");
            }
            else
            {
                System.Console.WriteLine("Something gone wrong");
            }
        }
       
    }
}
