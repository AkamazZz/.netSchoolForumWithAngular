using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Speciality;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Speciality_Service : ISpeciality_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<int> GetFacultyIdBySpecilaityId(int speciliaty_id)
        {
            Generic_ResultSet<Speciality_ResultSet> result = new Generic_ResultSet<Speciality_ResultSet>();
            try
            {
                //GET speciality FROM DB
                Speciality spec = await _crud.Read<Speciality>(speciality_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Speciality_ResultSet facultyReturned = new Speciality_ResultSet
                {
                    speciality_id = spec.Speciality_Id,
                    speciality_name = spec.Speciality_name,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetFacultyIdByFacultyName() method executed successfully.";
                result.result_set = facultyReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result.result_set.speciality_id;
            
        }

        public async Task<string> GetSpecilaityNameBySpecilaityId(int speciality_id)
        {
            Generic_ResultSet<Speciality_ResultSet> result = new Generic_ResultSet<Speciality_ResultSet>();
            try
            {
                //GET speciality FROM DB
                Speciality spec = await _crud.Read<Speciality>(speciality_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Speciality_ResultSet facultyReturned = new Speciality_ResultSet
                {
                    speciality_id = spec.Speciality_Id,
                    speciality_name = spec.Speciality_name,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetFacultyIdByFacultyName() method executed successfully.";
                result.result_set = facultyReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result.result_set.speciality_name;
                
        }
    }
}

