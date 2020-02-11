using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway;

        public DesignationManager()
        {
            designationGateway = new DesignationGateway();
        }



        public List<TeacherDesignation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }
    }
}