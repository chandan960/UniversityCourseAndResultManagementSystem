using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Controllers;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string InsertNewTeacher(Teacher teacher)
        {
            if (teacherGateway.IsEmailExist(teacher))
            {
                return "Same Email already Exist";
            }
            else
            {
                int rowAffected = teacherGateway.InsertNewTeacher(teacher);
                return rowAffected > 0 ? "New Teacher Successfully Added" : "Failed";
            }
        }
        
        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            return teacherGateway.GetAllTeacherByDepartment(departmentId);
        }
     
        public Teacher GetTeacherInformationById(int teacherId)
        {
            return teacherGateway.GetTeacherInformationById(teacherId);
        }
   
    }
}