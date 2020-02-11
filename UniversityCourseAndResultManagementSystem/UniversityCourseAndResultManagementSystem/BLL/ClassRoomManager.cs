using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class ClassRoomManager
    {
        private ClassRoomGateway classRoomGateway;

        public ClassRoomManager()
        {
            classRoomGateway = new ClassRoomGateway();
        }

        public List<ClassRoom> GetAllClassRooms()
        {
            return classRoomGateway.GetAllClassRooms();
        }
          public string AllocateNewClassRoom(ClassRoomAllocation classRoomAllocation)
          {

              if (!classRoomGateway.IsAllocateClassRoomNotExist(classRoomAllocation))
              {
                  return "Can not Possible";
              }
              else
              {

                  int rowAffected = classRoomGateway.AllocateNewClassRoom(classRoomAllocation);
                  return rowAffected > 0 ? "Class Room Allocated Successfully" : "Failed";
              }

          }

    }
}