using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hierarchy.Controllers
{

    public class FacultyController
    {
        private IFaculty_Service _faculty_Service = new Faculty_Service();
        private StudentController _student_con = new StudentController();

        public async void GetEachFaculty()
        {
            var result = await _faculty_Service.GetAllFaculties();
            switch (result.success)
            {
                case true:
                    if (result.result_set.Count() != 0)
                    {
                        int i = 1;
                        foreach (var res in result.result_set)
                        {
                            System.Console.WriteLine($"{i}. {res.faculty_name}");
                            i++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"This faculty is empty");
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is not faculties in this university");
                    break;
            }
        }
        public async void GetTopByFaculty(int faculty_id)
        {
            var result = await _faculty_Service.GetTopByGpaInFaculty(faculty_id);
            switch (result.success)
            {
                case true:
                    if(result.result_set_dictionary.Count() != 0) { 
                    int i = 1;
                    Console.WriteLine("Rating among faculty");
                        foreach (var res in result.result_set_dictionary)
                        {
                            List<string> student = await _student_con.GetFullNameById(res.Key);
                            Console.WriteLine($"{i}. {student.ElementAt(0)} {student.ElementAt(1)}: {res.Value}%");
                            ++i;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"This faculty is empty");
                    }
                    break;
                case false:
                    Console.WriteLine("Faculty doesn't have anyone");
                    break;
            }
        }
        public async Task<string> GetFacultyNameById(int faculty_id)
        {
            var result = await _faculty_Service.GetFacultyNameByFacultyId(faculty_id);
            if(result != null)
            {
                return result.result_set.faculty_name ;
            }
            else
            {
                return "This faculty doesn't exist";
            }
        }
    }
}
