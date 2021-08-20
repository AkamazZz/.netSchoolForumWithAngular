using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hierarchy.Controllers
{

    public class SubjectController
    {
        private ISubject_Service _subject_Service = new Subject_Service();


        public async void GetSubjectNameBySubjectId(int subject_id)
        {
            var result = await _subject_Service.GetSubjectNameBySubjectId(subject_id);
            switch (result.success)
            {
                case true:
                    System.Console.WriteLine(result.result_set.subject_name);
                    break;
                case false:
                    System.Console.WriteLine("There is no such subject");
                    break;
            }
        }

        public async void GetSubjectsNameByStudentId(int student_id)
        {
            var result = await _subject_Service.GetSubjectsNameByStudentId(student_id);
            switch (result.Count)
            {
                case int i when i >= 1:
                    int n = 1;
                    System.Console.WriteLine("List of subjects: ");
                    for (int k = 0; k < result.Count; k++)
                    {
                        System.Console.WriteLine($"{n}. {result.ElementAt(k)}");
                        ++n;
                    }
                    break;
                default:
                    System.Console.WriteLine("There is no such subject");
                    break;
            }
        }


   
           
        }
    }

