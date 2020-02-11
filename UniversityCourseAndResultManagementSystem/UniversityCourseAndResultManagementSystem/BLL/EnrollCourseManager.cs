using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class EnrollCourseManager
    {
        private EnrollCourseGateway enrollCoursesGateway;

        public EnrollCourseManager()
        {
            enrollCoursesGateway = new EnrollCourseGateway();
        }

        public string AssignNewCourseToStudent(EnrollInCourse enrollInCourse)
        {
            if (enrollCoursesGateway.IsCourseIdAndStudentIdExist(enrollInCourse))
            {
                return "This Course already Taken by this Student";
            }
            else
            {
                int rowAffected = enrollCoursesGateway.EnrollNewCourseToStudent(enrollInCourse);
                return rowAffected > 0 ? "This Course Successfully Enrolled to the Student" : "Failed";
            }
        }
    }
}