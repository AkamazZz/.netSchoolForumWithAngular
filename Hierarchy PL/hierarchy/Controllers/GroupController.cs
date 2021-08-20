using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hierarchy.Controllers
{

    public class GroupController
    {
        private IGroup_Service _group_Service = new Group_Service();
        private StudentController _student_con = new StudentController();

        public async void GetTopByGroup(int group_id)
        {
            var result = await _group_Service.GetTopByGpaInGroup(group_id);
            switch (result.success)
            {
                case true:
                    if (result.result_set_dictionary.Count() != 0)
                    {
                        int i = 1;
                        Console.WriteLine("Rating among groups");
                        foreach (var res in result.result_set_dictionary)
                        {
                            List<string> student = await _student_con.GetFullNameById(res.Key);
                            Console.WriteLine($"{i}. {student.ElementAt(0)} {student.ElementAt(1)}: {res.Value}%");
                            ++i;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"This group is Empty");
                    }
                        break;
                case false:
                    Console.WriteLine("This group is empty");
                    break;
            }
        }
        public async Task<string> GetGroupNameById(int group_id)
        {
            var result = await _group_Service.GetGroupNameByGroupId(group_id);
            switch (result.success)
            {
                case true: 
                    return result.result_set.group_name;
                case false:
                    return "Something went wrong";
            }
        }
        public async void GetEachGroup()
        {
            var result = await _group_Service.GetAllGroups();
            switch (result.success)
            {
                case true:
                    int i = 1;
                    foreach(var res in result.result_set)
                    {
                        System.Console.WriteLine($"{i}. {res.group_name}");
                        i++;
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is not groups in this university");
                    break;
            }
        }

    }
}
