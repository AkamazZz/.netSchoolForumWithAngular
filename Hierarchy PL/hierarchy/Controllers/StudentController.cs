using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ClosedXML.Attributes;
using ClosedXML.Utils;
using System.IO;

namespace Hierarchy.Controllers
{

    public class StudentController
    {
        private IStudent_Service _student_Service = new Student_Service();
        

        public async Task<List<string>> GetFullNameById(int student_id)
        {
            var result = await _student_Service.GetNameAndSurnameByStudentId(student_id);
            List<string> list = new List<string>();
            list.Add(result.result_set.student_name);
            list.Add(result.result_set.student_surname);

            switch (result.success)
            {
                case true:
                    return list;
                case false:
                    return null;
            }
        }

        public async void GetEachStudentOfFaculty(int faculty_id)
        {
            var result = await _student_Service.GetAllStudentOfFaculty(faculty_id);
            switch (result.success)
            {
                case true:
                    int i = 1;
                    foreach (var st in result.result_set)
                    {
                        System.Console.WriteLine($"{0}. {1} {2}", i, st.student_name, st.student_surname);
                        ++i;
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is no such faculty");
                    break;
            }
        }


        public async void GetEachStudentOfSpeciality(int speciality_id)
        {
            var result = await _student_Service.GetAllStudentOfSpecilaity(speciality_id);
            switch (result.success)
            {
                case true:
                    int i = 1;
                    foreach (var st in result.result_set)
                    {
                        System.Console.WriteLine($"{0}. {1} {2}", i, st.student_name, st.student_surname);
                        ++i;
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is no such speciality");
                    break;
            }
        }

        public void GetEachStudentOfGroup(int group_id)
        {
            var result =  _student_Service.GetAllStudentOfGroup(group_id);
            switch (result.success)
            {
                case true:
            
                    foreach (var st in result.result_set)
                    {
                        
                        System.Console.WriteLine($"{st.student_id}. {st.student_name} {st.student_surname}");
                    }
                    break;
                case false:
                    System.Console.WriteLine("There is no such group");
                    break;
            }
        }
        public async Task<int> GetGroupId(int student_id)
            {
                var result = await _student_Service.GetGroupIdByStudentId(student_id);
                switch (result.success)
                {
                    case true:

                    return result.result_set.group_id;

                    case false:
                        System.Console.WriteLine("There is no such student");
                    return 0 ; // if >=0
                }
            }
        public async void GetWholeInfoAboutStudentByNameAndSurname(string name, string surname)
        {
            FacultyController faculty_controller = new FacultyController();
            SpecialityController spec_controller = new SpecialityController();
            GroupController group_controller = new GroupController();
        var result = await _student_Service.GetStudentByFullName(name, surname);
            switch (result.success)
            {
                case true:
                    string faculty = await faculty_controller.GetFacultyNameById(result.result_set.faculty_id);
                    string spec = await spec_controller.GetSpecialityNameById(result.result_set.speciality_id); 
                    string group = await group_controller.GetGroupNameById(result.result_set.group_id);
                    Console.WriteLine($"Student belongs to\n" +
                        $" faculty: {faculty}\n" +
                        $" Speciality: {spec}\n" +
                        $" Group: {group}");
                    break;

                case false:
                    Console.WriteLine("There is no such student");
                    break;
            }
        }

        public async void GetWholeInfoAboutStudentById(int id)
        {
            FacultyController faculty_controller = new FacultyController();
            SpecialityController spec_controller = new SpecialityController();
            GroupController group_controller = new GroupController();
            var result = await _student_Service.GetNameAndSurnameByStudentId(id);
            switch (result.success)
            {
                case true:
                    string faculty = await faculty_controller.GetFacultyNameById(result.result_set.faculty_id);
                    string spec = await spec_controller.GetSpecialityNameById(result.result_set.speciality_id);
                    string group = await group_controller.GetGroupNameById(result.result_set.group_id);
                    Console.WriteLine($"Student belongs to\n" +
                        $" faculty: {faculty}\n" +
                        $" Speciality: {spec}\n" +
                        $" Group: {group}");
                    break;

                case false:
                    Console.WriteLine("There is no such student");
                    break;
            }
        }
        public async void SaveInfoAboutStudents()
        {
            FacultyController faculty_controller = new FacultyController();
            SpecialityController spec_controller = new SpecialityController();
            GroupController group_controller = new GroupController();
            var result = await _student_Service.GetAllStudents();
            try
            {
                XLWorkbook wb = new XLWorkbook();
                List<string> group = new List<string>();
                foreach (var res in result.result_set)
                {
                    string t_group = await group_controller.GetGroupNameById(res.group_id);
                    group.Add(t_group);
                }
                List<string> speciality = new List<string>();
                foreach (var res in result.result_set)
                {
                    string t_spec = await spec_controller.GetSpecialityNameById(res.speciality_id);
                    speciality.Add(t_spec);
                }
                List<string> faculty = new List<string>();
                foreach (var res in result.result_set)
                {
                    string t_faculty = await faculty_controller.GetFacultyNameById(res.faculty_id);
                    faculty.Add(t_faculty);
                }
                var ws = wb.Worksheets.Add("Students");
                var students = from s in result.result_set
                               select new { s.student_id, s.student_name, s.student_surname };
                ws.Cell(1, 1).Value = "Id";
                ws.Cell(1, 2).Value = "Name";
                ws.Cell(1, 3).Value = "Surname";
                ws.Cell(1, 4).Value = "Faculty";
                ws.Cell(1, 5).Value = "Speciality";
                ws.Cell(1, 6).Value = "Group";
                ws.Range(1, 1, 1, 6).Style.Fill.BackgroundColor = XLColor.LightGreen;
                ws.Range(1, 1, 1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = students.AsEnumerable();
                ws.Cell(2, 4).Value = faculty.AsEnumerable();
                ws.Cell(2, 5).Value = speciality.AsEnumerable();
                ws.Cell(2, 6).Value = group.AsEnumerable();
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string savePath = Path.Combine(desktopPath, "Students.xlsx");
                wb.SaveAs(savePath, false);
                Console.WriteLine("Checkout your desktop (Students is name of excel file)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The database is empty");
            }



        }
    }
    }
