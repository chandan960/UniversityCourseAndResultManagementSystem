using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class StudentResultManager
    {
        private StudentResultGateway studentResultGateway;

        public StudentResultManager()
        {
            studentResultGateway = new StudentResultGateway();
        }

        public List<GradeLetter> GetAllGrades()
        {
            return studentResultGateway.GetAllGrades();
        }
        public List<Course> GetAllTakenCourses(int studentId)
        {
            return studentResultGateway.GetAllTakenCourses(studentId);
        }
        public string SaveAResult(StudentResult studentResult)
        {
            if (studentResultGateway.SaveAResult(studentResult) == 1)
            {
                return "Result Successfully Saved";
            }
            else
            {
                return "Failed";
            }
        }

        public List<StudentResult> GetAllResultByStudentId(int studentId)
        {
            return studentResultGateway.GetAllResultByStudentId(studentId);
        }
    }
}