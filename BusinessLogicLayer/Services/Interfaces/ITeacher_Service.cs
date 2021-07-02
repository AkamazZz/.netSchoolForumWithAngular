using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Teacher;
using System.Threading.Tasks;
using System;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ITeacher_Service
    {
        Task<Generic_ResultSet<Teacher_ResultSet>> GetNameAndSurnameById(string teacher_name, string teacher_surname);
    }
}
