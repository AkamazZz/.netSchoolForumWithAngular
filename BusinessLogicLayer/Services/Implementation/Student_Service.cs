using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Students;
using BusinessLogicLayer.Services.Interfaces;
namespace BusinessLogicLayer.Services.Implementation
{
    public class Student_Service : IStudent_Service
    {
        private readonly ICRUD _crud = new CRUD();
        private IFacultySpecific _faculty = new FacultySpecific();
        private ISpecialitySpecific _spec = new SpecialitySpecific();
        private IGroupSpecific _group = new GroupSpecific();
        private IStudentSpecific _student = new StudentSpecific();


        public async Task<Generic_ResultSet<Student_ResultSet>> GetTopOfStudents()
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                Dictionary<int, double> student = await _student.GetTop();

                result.userMessage = string.Format("Top is provided");
                result.internalMessage = "GetTopOfStudents() method executed successfully.";
                result.success = true;
                result.result_set_dictionary = student;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "There is no students";
                result.internalMessage = string.Format("ERROR: GetTopOfStudents(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfFaculty(int faculty_id)
        {
            Generic_ResultSet<List<Student_ResultSet>> result = new Generic_ResultSet<List<Student_ResultSet>>();
            try
            {
                //GET Student FROM DB
                List<Student> student = await _crud.ReadAll<Student>();

                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet

                result.result_set = new List<Student_ResultSet>();
                student.ForEach(s =>
                {   
                    if(s.Faculty_Id == faculty_id)
                {
                    result.result_set.Add(new Student_ResultSet
                    {
                        student_id = s.Student_Id,
                        university_id = s.University_Id,
                        speciality_id = s.Speciality_Id,
                        faculty_id = s.Faculty_Id,
                        group_id = s.Group_Id,
                        student_name = s.FirstName,
                        student_surname = s.LastName,
                    });
                        }
                });
                


                /*Student_ResultSet StudentReturned = new Student_ResultSet
                 {
                     student_id = student.Student_Id,
                     university_id = student.University_Id,
                     speciality_id = student.Speciality_Id,
                     faculty_id = student.Faculty_Id,
                     group_id = student.Group_Id,
                     student_name = student.FirstName,
                     student_surname = student.LastName,
                 };
                */
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Students from {0} faculty", faculty_id);
                result.internalMessage = "GetAllStudentOfFaculty(int faculty_id) method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("ERROR: GetAllStudentOfFaculty(int faculty_id): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfSpecilaity(int speciality_id)
        {
            Generic_ResultSet<List<Student_ResultSet>> result = new Generic_ResultSet<List<Student_ResultSet>>();
            try
            {
                //GET Student FROM DB
                List<Student> student = await _crud.ReadAll<Student>();

                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet

                result.result_set = new List<Student_ResultSet>();
                student.ForEach(s =>
                {
                    if (s.Speciality_Id == speciality_id)
                    {
                        result.result_set.Add(new Student_ResultSet
                        {
                            student_name = s.FirstName,
                            student_surname = s.LastName,
                        });
                    }
                });

                /*Student_ResultSet StudentReturned = new Student_ResultSet
                 {
                     student_id = student.Student_Id,
                     university_id = student.University_Id,
                     speciality_id = student.Speciality_Id,
                     faculty_id = student.Faculty_Id,
                     group_id = student.Group_Id,
                     student_name = student.FirstName,
                     student_surname = student.LastName,
                 };
                */
                int i = 1;
               foreach(var s in result.result_set)
                { 
                    System.Console.WriteLine($"{0}. {1} {2} ", i , s.student_name, s.student_surname);
                    ++i;
                }
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Students from {0} speciality", speciality_id);
                result.internalMessage = "GetAllStudentOfspeciality(int speciality_id) method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This speciality doesn't exist";
                result.internalMessage = string.Format("ERROR: GetAllStudentOfSpeciality(int faculty_id): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Student_ResultSet>> GetGroupIdByStudentId(int student_id)
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                //GET Student FROM DB
                Student student = await _crud.Read<Student>(student_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Student_ResultSet studentReturned = new Student_ResultSet
                {
                    student_id = student.Student_Id,
                    university_id = student.University_Id,
                    speciality_id = student.Speciality_Id,
                    faculty_id = student.Faculty_Id,
                    group_id = student.Group_Id,
                    student_name = student.FirstName,
                    student_surname = student.LastName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetStudentByGroupId() method executed successfully.";
                result.result_set = studentReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This student doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Student_ResultSet>> UpdateStudent(int student_id, int faculty_id, int speciality_id, int group_id , string name, string surname)
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                if (student_id != null && speciality_id != null && faculty_id !=null
                    && group_id != null && name != null && surname != null) { 
                //GET Student FROM DB
                Student studentToUpdate = new Student
                {
                    Student_Id = student_id,
                    University_Id = 1,
                    Speciality_Id = speciality_id,
                    Faculty_Id = faculty_id,
                    Group_Id = group_id,
                    FirstName = caseConversion.firstCaseToUpper(name),
                    LastName = caseConversion.firstCaseToUpper(surname),
                };
                
                    studentToUpdate = await _crud.Update<Student>(studentToUpdate, student_id);
                    //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                    Student_ResultSet studentReturned = new Student_ResultSet
                    {
                        student_id = studentToUpdate.Student_Id,
                        university_id = studentToUpdate.University_Id,
                        speciality_id = studentToUpdate.Speciality_Id,
                        faculty_id = studentToUpdate.Faculty_Id,
                        group_id = studentToUpdate.Group_Id,
                        student_name = studentToUpdate.FirstName,
                        student_surname = studentToUpdate.LastName,
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format($"Student {studentReturned.student_name} {studentReturned.student_surname} has been changed");
                    result.internalMessage = "UpdateStudent() method executed successfully.";

                    result.success = true;
                }
                
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This student doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Student_ResultSet>> DeleteStudent(int student_id)
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                var isDeleted = await _student.DeleteStudent(student_id);
                

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The student has been deleted");
                result.internalMessage = "DeleteStudent() method executed successfully.";

                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This student doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Student_ResultSet>> AddSingleStudent(int speciality_id, int faculty_id, int group_id, string name, string surname )
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                //GET Student FROM DB
                Student student = new Student{
                    University_Id =1,
                    Speciality_Id = speciality_id,
                    Faculty_Id = faculty_id,
                    Group_Id=group_id,
                    FirstName = caseConversion.firstCaseToUpper(name),
                    LastName = caseConversion.firstCaseToUpper(surname),
                    };
                student = await _crud.Create<Student>(student);
                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Student_ResultSet studentReturned = new Student_ResultSet
                {
                    student_id = student.Student_Id,
                    university_id = student.University_Id,
                    speciality_id = student.Speciality_Id,
                    faculty_id = student.Faculty_Id,
                    group_id = student.Group_Id,
                    student_name = student.FirstName,
                    student_surname = student.LastName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "AddSingleStudent() method executed successfully.";
                
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This student doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Student_ResultSet>> GetNameAndSurnameByStudentId(int student_id)
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                //GET Student FROM DB
                Student student = await _crud.Read<Student>(student_id);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Student_ResultSet studentReturned = new Student_ResultSet
                {
                    student_id = student.Student_Id,
                    university_id = student.University_Id,
                    speciality_id = student.Speciality_Id,
                    faculty_id = student.Faculty_Id,
                    group_id = student.Group_Id,
                    student_name = student.FirstName,
                    student_surname = student.LastName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Student name is {0}, surname is {1}", student.FirstName, student.LastName);
                result.internalMessage = "GetNameAndSurnameByStudentId() method executed successfully.";
                result.result_set = studentReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "There is no such student with this name and surname";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfGroup(int group_id)
        {
            Generic_ResultSet<List<Student_ResultSet>> result =  new Generic_ResultSet<List<Student_ResultSet>>();
            try
            {
                //GET Student FROM DB
                List<Student> student = await  _group.GetAllFromGroup(group_id);


                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet

                result.result_set = new List<Student_ResultSet>();
                student.ForEach(s =>
                {
                    {
                        result.result_set.Add(new Student_ResultSet
                        {
                            student_id = s.Student_Id,
                            university_id = s.University_Id,
                            speciality_id = s.Speciality_Id,
                            faculty_id = s.Faculty_Id,
                            group_id = s.Group_Id,
                            student_name = s.FirstName,
                            student_surname = s.LastName,
                        });
                    }
                });



                /*Student_ResultSet StudentReturned = new Student_ResultSet
                 {
                     student_id = student.Student_Id,
                     university_id = student.University_Id,
                     speciality_id = student.Speciality_Id,
                     faculty_id = student.Faculty_Id,
                     group_id = student.Group_Id,
                     student_name = student.FirstName,
                     student_surname = student.LastName,
                 };
                */
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Students from {0} group",  group_id);
                result.internalMessage = "GetAllStudentOfFaculty(int faculty_id) method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("ERROR: GetAllStudentOfFaculty(int faculty_id): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudents()
        {
            Generic_ResultSet<List<Student_ResultSet>> result = new Generic_ResultSet<List<Student_ResultSet>>();
            try
            {
                //GET Student FROM DB
                List<Student> student = await _student.GetAllStudents();
               // List<Student> student = await _crud.ReadAll<Student>();


                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet

                result.result_set = new List<Student_ResultSet>();
                student.ForEach( s =>
                {
                    Faculty faculty = _crud.ReadSync<Faculty>(s.Faculty_Id);
                    Speciality spec =  _crud.ReadSync<Speciality>(s.Speciality_Id);
                    Group group =  _crud.ReadSync<Group>(s.Group_Id);

                    {
                        result.result_set.Add(new Student_ResultSet
                        {
                            student_id = s.Student_Id,
                            university_id = s.University_Id,
                            speciality_id = s.Speciality_Id,
                            speciality_name = spec.Speciality_name,
                            faculty_id = s.Faculty_Id,
                            faculty_name = faculty.Faculty_name,
                            group_id = s.Group_Id,
                            group_name = group.Group_Name,
                            student_name = s.FirstName,
                            student_surname = s.LastName,
                        }) ;
                    }
                });



                
                result.userMessage = string.Format("Here is the students");
                result.internalMessage = "GetAllStudent() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "No students here";
                result.internalMessage = string.Format($"ERROR: GetAllStudent(): {exception.Message}");
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Student_ResultSet>> GetStudentByFullName(string name, string surname)
        {
            Generic_ResultSet<Student_ResultSet> result = new Generic_ResultSet<Student_ResultSet>();
            try
            {
                //GET Student FROM DB
                Student student = await _student.GetStudentIdByFullName(name, surname);

                //MANUAL MAPPING OF RETURNED student VALUES TO OUR student_ResultSet
                Student_ResultSet studentReturned = new Student_ResultSet
                {
                    student_id = student.Student_Id,
                    university_id = student.University_Id,
                    speciality_id = student.Speciality_Id,
                    faculty_id = student.Faculty_Id,
                    group_id = student.Group_Id,
                    student_name = student.FirstName,
                    student_surname = student.LastName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetStudentByGroupId() method executed successfully.";
                result.result_set = studentReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This student doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}

