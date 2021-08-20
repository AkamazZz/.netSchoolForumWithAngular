using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Students;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Models.Group;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Group_Service : IGroup_Service
    {
        private readonly ICRUD _crud = new CRUD();
        private IGroupSpecific _group = new GroupSpecific();

        public async Task<Generic_ResultSet<Group_ResultSet>> GetGroupNameByGroupId(int group_id)
        {
            Generic_ResultSet<Group_ResultSet> result = new Generic_ResultSet<Group_ResultSet>();
            try
            {
         
                Group group = await _crud.Read<Group>(group_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Group_ResultSet groupReturned = new Group_ResultSet
                {
                    group_id = group.Group_Id,
                    group_name = group.Group_Name,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("{0}", groupReturned.group_name);
                result.internalMessage = "GetGroupNameByGroupId(int group_id) method executed successfully.";
                result.result_set = groupReturned;
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
        public async Task<Generic_ResultSet<List<Group_ResultSet>>> GetAllGroups()
        {
           Generic_ResultSet<List<Group_ResultSet>> result = new Generic_ResultSet<List<Group_ResultSet>>();
            try
            {

                List<Group> group = await _crud.ReadAll<Group>();

                result.result_set = new List<Group_ResultSet>();
                group.ForEach(s =>
                {
                    
                        result.result_set.Add(new Group_ResultSet
                        {
                            group_id = s.Group_Id,
                            group_name = s.Group_Name,
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
        public async Task<Generic_ResultSet<Group_ResultSet>> GetTopByGpaInGroup(int group_id)
        {
            Generic_ResultSet<Group_ResultSet> result = new Generic_ResultSet<Group_ResultSet>();

            try
            {
                //GET Faculty FROM DB
                Dictionary<int, double> group =  await _group.GetTopFromGroup(group_id);



                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetFacultyIdByFacultyName() method executed successfully.";
                result.result_set_dictionary = group;
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

