using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Speciality;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISpeciality_Service
    {
        Task<Generic_ResultSet<Speciality_ResultSet>> GetSpecialityNameByFacultyIdAndSpecilaityId(int grade, int student_id, int subject_id);
        

    
    }
}
