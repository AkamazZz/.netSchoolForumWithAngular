using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Speciality;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISpeciality_Service
    {

        Task<Generic_ResultSet<List<Speciality_ResultSet>>> GetAllSpecialities();
        Task<Generic_ResultSet<Speciality_ResultSet>> GetSpecilaityNameBySpecilaityId(int speciliaty_id);

        Task<Generic_ResultSet<Speciality_ResultSet>> GetFacultyIdBySpecilaityId(int speciliaty_id);

        Task<Generic_ResultSet<Speciality_ResultSet>> GetTopByGpaInSpeciality(int speciality_id);
    }
}
