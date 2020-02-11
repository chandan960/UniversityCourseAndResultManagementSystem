using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class CoursesManager
    {
        private CoursesGateway coursesGateway;

        public CoursesManager()
        {
            coursesGateway = new CoursesGateway();
        }

        public string InsertNewCourse(Course course)
        {
            if (coursesGateway.IsCodeExist(course))
            {
                return "Same Code already Exist";
            }
            else if (coursesGateway.IsNameExist(course))
            {
                return "Same Name already Exist";
            }
            else
            {
                int rowAffected = coursesGateway.InsertNewCourse(course);
                return rowAffected > 0 ? "New Course Successfully Added" : "Failed";
            }
        }
      
        public List<Course> GetAllUnAssignCoursesByDeptId(int deptId)
        {
            return coursesGateway.GetAllUnAssignCoursesByDeptId(deptId);
        }
        public Course GetCourseInformationByCourseId(int courseId)
        {
            return coursesGateway.GetCourseInformationByCourseId(courseId);
        }
          public List<Course> GetAllCoursesByDeptId(int deptId)
          {
              return coursesGateway.GetAllCoursesByDeptId(deptId);
          }

        public List<Course> GetCourseByStudentId(String studentId)
        {
            return coursesGateway.GetCourseByStudentId(studentId);
        }

       
    }
}