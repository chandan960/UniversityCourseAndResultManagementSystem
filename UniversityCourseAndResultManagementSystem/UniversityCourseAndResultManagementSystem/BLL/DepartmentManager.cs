using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {

            departmentGateway = new DepartmentGateway();
        }

        public string InsertNewDepartment(Department department)
        {
            if (departmentGateway.IsCodeExist(department))
            {
                return "Same Code already Exist";
            }
            else if (departmentGateway.IsNameExist(department))
            {
                return "Same Name already Exist";
            }
            else
            {
                int rowAffected = departmentGateway.InsertNewDepartment(department);
                return rowAffected > 0 ? "New Department Successfully Added" : "Failed";
            }
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }

        public string GetDepartmentCode(int deptId)
        {
            return departmentGateway.GetDepartmentCode(deptId);
        }
    }
}