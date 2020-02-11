using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class CourseAssignManager
    {
        private CourseAssignGateway courseAssignGateway;

        public CourseAssignManager()
        {
            courseAssignGateway = new CourseAssignGateway();
        }

        public string AssignNewCourse(CourseAssign courseAssign)
        {
            int rowAffected = courseAssignGateway.AssignNewCourse(courseAssign);
            return rowAffected > 0 ? "Course assign to Teacher Successfully" : "Failed";
        }
        public string UnAssignCourses()
        {
            EnrollCourseGateway enrollCourseGateway  = new EnrollCourseGateway();
            int rowAffected1 = courseAssignGateway.UnAssignCourses();
            int rowAffected2 = enrollCourseGateway.DisEnrollCourses();
            if (rowAffected2 > 0 && rowAffected1 > 0)
            {
                return "Unassign Courses Successfully";
            }
            else
            {
                return "Failed";
            }

        }
    }
}