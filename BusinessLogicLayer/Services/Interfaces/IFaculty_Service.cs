using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Faculty;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IFaculty_Service
    {
        Task<string> GetFacultyNameByFacultyId(int faculty_id);


    }
}
