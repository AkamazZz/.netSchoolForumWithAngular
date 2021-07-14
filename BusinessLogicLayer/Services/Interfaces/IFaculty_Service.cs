using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Faculty;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IFaculty_Service
    {
        Task<Generic_ResultSet<List<Faculty_ResultSet>>> GetAllFaculties();
        Task<Generic_ResultSet<Faculty_ResultSet>> GetFacultyNameByFacultyId(int faculty_id);

        Task<Generic_ResultSet<Faculty_ResultSet>> GetTopByGpaInFaculty (int faculty_id);

    }
}
