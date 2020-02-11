using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class ClassScheduleViewManager
    {
        private ClassScheduleViewGateway classScheduleViewGateway;

        public ClassScheduleViewManager()
        {
            classScheduleViewGateway = new ClassScheduleViewGateway();
        }

        public List<ClassScheduleView> GetAllClassScheduleViewsByDeptId(int deptId)
        {
            return classScheduleViewGateway.GetAllClassScheduleViewsByDeptId(deptId);
        }
        public string UnAllocateClassRoom()
        {
            int rowAffected = classScheduleViewGateway.UnAllocateClassRoom();
            if (rowAffected > 0)
            {
                return "All Classes Successfully Unallocated";
            }
            else
            {
                return "Failed";
            }
        }
    }
}