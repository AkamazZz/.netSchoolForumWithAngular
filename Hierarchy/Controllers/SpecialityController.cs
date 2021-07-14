using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hierarchy.Controllers
{

    public class SpecialityController
    {
        private ISpeciality_Service _speciality_Service = new Speciality_Service();
        private StudentController _student_con = new StudentController();


        public async void GetEachSpeciality()
        {
            var result = await _speciality_Service.GetAllSpecialities();
            switch (result.success)
            {
                case true:
                    int i = 1;
                    foreach (var res in result.result_set)
                    {
                        System.Console.WriteLine($"{i}. {res.speciality_name}");
                        i++;
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is not specialities in this university");
                    break;
            }
        }
        public async void GetTopBySpeciality(int speciality_id)
        {
            var result = await _speciality_Service.GetTopByGpaInSpeciality(speciality_id);
            switch (result.success)
            {
                case true:
                    int i = 1;
                    if (result.result_set_dictionary.Count() != 0)
                    {
                        Console.WriteLine("Rating among speciality");
                        foreach (var res in result.result_set_dictionary)
                        {
                            List<string> student = await _student_con.GetFullNameById(res.Key);
                            Console.WriteLine($"{i}. {student.ElementAt(0)} {student.ElementAt(1)}: {res.Value}%");
                            ++i;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"This speciality is empty");
                    }
                    break;
                case false:
                    Console.WriteLine("There is no one in this speciality");
                    break;
            }
        }
        public async Task<string> GetSpecialityNameById(int speciality_id)
        {
            var result = await _speciality_Service.GetSpecilaityNameBySpecilaityId(speciality_id);
            if(result != null)
            {
                return result;
            }
            else
            {
                return "This speciality doesn't exist";
            }
        }
        public async Task<int> GetFacultyIdById(int speciality_id)
        {
            var result = await _speciality_Service.GetFacultyIdBySpecilaityId(speciality_id);
            if (result >= 0)
            {
                return result;
            }
            else
            {
                return 0; // if return 0 there is no faculty exist
            }
        }
    }
}
