﻿using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Student;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Student_Service : IStudent_Service
    {
        private readonly ICRUD _crud = new CRUD();
   

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

        public async Task<int> GetGroupIdByStudentId(int student_id)
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
            return result.result_set.group_id;
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
    }
}
