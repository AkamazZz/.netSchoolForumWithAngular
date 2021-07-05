using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Speciality;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISpeciality_Service
    {
        Task<string> GetSpecilaityNameBySpecilaityId(int speciliaty_id);

        Task<int> GetFacultyIdBySpecilaityId(int speciliaty_id);
    }
}
