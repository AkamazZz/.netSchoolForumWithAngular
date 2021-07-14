using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Faculty;
using BusinessLogicLayer.Services.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Faculty_Service : IFaculty_Service
    {
        private ICRUD _crud = new CRUD();
        private IFacultySpecific _faculty = new FacultySpecific();

        public async Task<Generic_ResultSet<List<Faculty_ResultSet>>> GetAllFaculties()
        {
            Generic_ResultSet<List<Faculty_ResultSet>> result = new Generic_ResultSet<List<Faculty_ResultSet>>();
            try
            {

                List<Faculty> group = await _crud.ReadAll<Faculty>();

                result.result_set = new List<Faculty_ResultSet>();
                group.ForEach(s =>
                {

                    result.result_set.Add(new Faculty_ResultSet
                    {
                        faculty_id = s.Faculty_Id,
                        faculty_name = s.Faculty_name,
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
        public async  Task<Generic_ResultSet<Faculty_ResultSet>> GetFacultyNameByFacultyId(int faculty_id)
        {
            Generic_ResultSet<Faculty_ResultSet> result = new Generic_ResultSet<Faculty_ResultSet>();
            try
            {
                //GET Faculty FROM DB
                Faculty faculty =  await _crud.Read<Faculty>(faculty_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Faculty_ResultSet facultyReturned = new Faculty_ResultSet
                {
                    faculty_id = faculty.Faculty_Id,
                    faculty_name = faculty.Faculty_name,
                    
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

        public async Task<Generic_ResultSet<Faculty_ResultSet>> GetTopByGpaInFaculty(int faculty_id)
        {
            Generic_ResultSet<Faculty_ResultSet> result = new Generic_ResultSet<Faculty_ResultSet>();
            try
            {
                //GET Faculty FROM DB
                var faculty = await _faculty.GetTopFromFaculty(faculty_id);
               

                

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetFacultyIdByFacultyName() method executed successfully.";
                result.result_set_dictionary = faculty;
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

