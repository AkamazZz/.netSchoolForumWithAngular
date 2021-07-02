using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Speciality;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISpeciality_Service
    {
        Task<Generic_ResultSet<Speciality_ResultSet>> GetSpecialityIdByFacultyNameAndSpecilaityName(string faculty_name, string speciality_name);
        

    
    }
}
