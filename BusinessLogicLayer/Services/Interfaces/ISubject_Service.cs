﻿using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Subject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISubject_Service
    {
        Task<Generic_ResultSet<Subject_ResultSet>> GetSubjectNameBySubjectId(int subject_id);
        Task<List<string>> GetSubjectsNameByStudentId(int student_id);


    }
}
