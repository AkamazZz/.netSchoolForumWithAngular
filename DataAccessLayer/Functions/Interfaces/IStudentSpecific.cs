using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IStudentSpecific
    {

        public Task<Dictionary<int, double>> GetTop();
        public Task<List<Student>> GetAllStudents();

        public Task<bool> DeleteStudent(int student_id);

        public Task<Student> GetStudentIdByFullName(string name, string surname);
    }
}
