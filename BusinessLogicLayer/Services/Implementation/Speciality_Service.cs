using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Functions.Specific;
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
        private ISpecialitySpecific _spec = new SpecialitySpecific();

        public async Task<Generic_ResultSet<List<Speciality_ResultSet>>> GetAllSpecialities()
        {
            Generic_ResultSet<List<Speciality_ResultSet>> result = new Generic_ResultSet<List<Speciality_ResultSet>>();
            try
            {

                List<Speciality> group = await _crud.ReadAll<Speciality>();

                result.result_set = new List<Speciality_ResultSet>();
                group.ForEach(s =>
                {

                    result.result_set.Add(new Speciality_ResultSet
                    {
                        speciality_id = s.Speciality_Id,
                        faculty_id = s.Faculty_Id,
                        speciality_name = s.Speciality_name,
                    });

                });

                //SET SUCCESSFUL RESULT VALUES

                result.internalMessage = "GetGroupNameByGroupId(int group_id) method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This group doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Speciality_ResultSet>> GetFacultyIdBySpecilaityId(int speciality_id)
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
            return result;
            
        }

        public async Task<Generic_ResultSet<Speciality_ResultSet>> GetSpecilaityNameBySpecilaityId(int speciality_id)
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
            return result;
                
        }
        public async Task<Generic_ResultSet<Speciality_ResultSet>> GetTopByGpaInSpeciality(int speciality_id)
        {
            Generic_ResultSet<Speciality_ResultSet> result = new Generic_ResultSet<Speciality_ResultSet>();
            try
            {
                //GET Faculty FROM DB
                var spec = await _spec.GetTopFromSpeciliaty(speciality_id);



                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetFacultyIdByFacultyName() method executed successfully.";
                result.result_set_dictionary = spec;
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
            return result;
        }
    }
}

