using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class SemesterManager
    {
        private SemesterGateway semesterGateway;

        public SemesterManager()
        {
            semesterGateway = new SemesterGateway();
        }



        public List<Semester> GetAllSemesters()
        {
            return semesterGateway.GetAllSemesters();
        }
    }
}