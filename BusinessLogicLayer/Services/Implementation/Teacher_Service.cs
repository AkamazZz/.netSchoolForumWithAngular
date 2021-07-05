using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Teacher;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Teacher_Service : ITeacher_Service
    {
        public Task<Generic_ResultSet<Teacher_ResultSet>> GetNameAndSurnameById(int teacher_id)
        {
            throw new NotImplementedException();
        }
    }
}

