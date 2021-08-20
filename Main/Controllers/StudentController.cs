using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ClosedXML.Attributes;
using ClosedXML.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Hierarchy.Models.Student;

namespace Hierarchy.Controllers

{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController: ControllerBase
    {
        private IStudent_Service _student_Service ;

        public StudentController(IStudent_Service student_Service)
        {
            _student_Service = student_Service;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTopByGPA()
        {
            var result = await _student_Service.GetTopOfStudents();
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddStudent(Student_Pass_Object student)
        {
            var result = await _student_Service.AddSingleStudent(student.speciality_id, student.faculty_id, student.group_id, student.student_name, student.student_surname);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
       
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteStudent(int student_id)
        {
            var result = await _student_Service.DeleteStudent(student_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateStudent(Student_Update_Object student)
        {
            var result = await _student_Service.UpdateStudent(student.student_id, student.faculty_id, student.speciality_id, student.group_id, student.student_name, student.student_surname);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEachStudentOfFaculty(int faculty_id)
        {
            var result = await _student_Service.GetAllStudentOfFaculty(faculty_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result); 
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEachStudentOfSpeciality(int speciality_id)
        {
            var result = await _student_Service.GetAllStudentOfSpecilaity(speciality_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEachStudentOfGroup(int group_id)
        {
            var result =await  _student_Service.GetAllStudentOfGroup(group_id);
            switch (result.success)
            {
                case true:

                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGroupByStudentId(int student_id)
            {
                var result = await _student_Service.GetGroupIdByStudentId(student_id);
                switch (result.success)
                {
                    case true:

                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
            }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetWholeInfoAboutStudentByNameAndSurname(string name, string surname)
        {
            
            
        var result = await _student_Service.GetStudentByFullName(name, surname);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetWholeInfoAboutStudentById(int id)
        {
            
            var result = await _student_Service.GetNameAndSurnameByStudentId(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllStudents()
        {

            var result = await _student_Service.GetAllStudents();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
        /*public async void SaveInfoAboutStudents()
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



        }*/
    }
 }
