using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class StudentManager
    {
        private StudentGateway studentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
        }
        public string InsertNewStudent(Student student)
        {
            if (studentGateway.IsEmailExist(student))
            {
                return "Same Email already Exist";
            }
            else
            {
                int rowAffected = studentGateway.InsertNewStudent(student);
                return rowAffected > 0 ? "New Student Added Successfully ." : "Failed";
            }
        }
        
        public string GetLastStudentRegNo(int deptId, string year)
        {
            return studentGateway.GetLastStudentRegNo(deptId, year);
        }

       

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }
        
       public Student GetStudentById(int studentId)
       {
           return studentGateway.GetStudentById(studentId);
       }

    }
}