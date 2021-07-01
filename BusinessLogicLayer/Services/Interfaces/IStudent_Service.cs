using System;
using BusinessLogicLayer.Services.Models.Student;
using BusinessLogicLayer.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IStudent_Service   
    {
        Task<Generic_ResultSet<Student_ResultSet>> AddSingleStundent(string student_name, string student_surname);
        Task<Generic_ResultSet<Student_ResultSet>> GetStudentIdByNameAndSurname(string student_name, string student_surname);
        Task<Generic_ResultSet<Student_ResultSet>> GetAllStudentOfFaculty(int faculty_id);
        Task<Generic_ResultSet<Student_ResultSet>> GetAllStudentOfSpecilaity(int speciliaty_id);
        Task<Generic_ResultSet<Student_ResultSet>> GetGroupIdByStudentId(int student_id);


    }
}
