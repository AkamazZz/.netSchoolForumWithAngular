using System;
using Hierarchy.Controllers;
using System.Collections.Generic;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Entity;
using System.Threading.Tasks;


namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupController GC = new GroupController();
            StudentController TC = new StudentController();
            AssessmentController AC = new AssessmentController();
            SubjectController SC = new SubjectController();
            FacultyController FC = new FacultyController();
            SpecialityController spec = new SpecialityController();
     

            Console.WriteLine("Welcome to our university database");
            while (true)
            {
                Console.WriteLine("\n" +
                    "1. Give a grade to student"
                    + "\n2. Look at student's information"
                        + " \n3. Rating by GPA"
                            + "\n4. Save information about students in excel\n");
                int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                    
                                Console.WriteLine("Choose from which group");
                                GC.GetEachGroup();
                                int group = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Choose one of the student (number before full name)");
                                TC.GetEachStudentOfGroup(group);
                                int student_id = int.Parse(Console.ReadLine());
                                SC.GetSubjectsNameByStudentId(student_id);
                                int subject_id = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Set your grade for this subject");
                                int grade = int.Parse(Console.ReadLine());
                                AC.UpdateGradeByStudentIdAndSubjectId(grade, student_id, subject_id);
                                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                 break;
                           /* case 2:
                                Console.WriteLine("Choose from which faculty");
                                FC.GetEachFaculty();
                                int group = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Choose one of the student (number before full name");
                                TC.GetEachStudentOfGroup(group);
                                int student_id = int.Parse(Console.ReadLine());
                                SC.GetSubjectsNameByStudentId(student_id);
                                int subject_id = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Set your grade for this subject");
                                int grade = int.Parse(Console.ReadLine());
                                AC.UpdateGradeByStudentIdAndSubjectId(grade, student_id, subject_id);
                                break;*/
              
                        case 2:
                        
                        Console.WriteLine("Input name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Input surname");
                        string surname = Console.ReadLine();
                        TC.GetWholeInfoAboutStudentByNameAndSurname(name, surname);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        break;
                    case 3:
                        Console.WriteLine("Top by\n" +
                            "1. Group\n" +
                            "2. Faculty\n" +
                            "3. Speciality");
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Choose from which group");
                                GC.GetEachGroup();
                                int group_id = int.Parse(Console.ReadLine());
                                GC.GetTopByGroup(group_id);
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                                break;
                            case 2:
                                Console.WriteLine("Choose from which Faculty");
                                FC.GetEachFaculty();
                                int faculty_id = int.Parse(Console.ReadLine());
                                FC.GetTopByFaculty(faculty_id);
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                                break;
                            case 3:
                                Console.WriteLine("Choose from which speciality");
                                spec.GetEachSpeciality();
                                int spec_id = int.Parse(Console.ReadLine());
                                spec.GetTopBySpeciality(spec_id);
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                break;


                        }
                        break;
                    case 4:
                        TC.SaveInfoAboutStudents();
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        break;
                    default:
                        Console.WriteLine("Incorrect value");
                        break;
                }
                }
            }
        }
    }

