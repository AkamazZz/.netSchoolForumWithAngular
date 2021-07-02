using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Faculty;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Faculty_Service : IFaculty_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Faculty_ResultSet>> GetFacultyIdByFacultyName(string faculty_name)
        {
            Generic_ResultSet<Faculty_ResultSet> result = new Generic_ResultSet<Faculty_ResultSet>();
            try
            {
                //GET Faculty FROM DB
                Faculty faculty = await _crud.Read<Faculty>(faculty_name);

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
    }
}

