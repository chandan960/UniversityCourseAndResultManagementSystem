using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class ViewAssignCoursesManager
    {
        private ViewAssignCoursesGateway viewAssignCoursesGateway;
        public ViewAssignCoursesManager()
        {
            viewAssignCoursesGateway = new ViewAssignCoursesGateway();
        }
        public List<ViewAssignCourse> GetAllAssignCourses(int deptId)
        {
            ViewAssignCoursesGateway viewAssignCoursesGateway = new ViewAssignCoursesGateway();
            return viewAssignCoursesGateway.GetAllAssignCourses(deptId);
        }
    }
}