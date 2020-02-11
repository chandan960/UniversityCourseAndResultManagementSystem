using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class ClassRoomGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public ClassRoomGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<ClassRoom> GetAllClassRooms()
        {
            string query = "SELECT *from ClassRoomTable order by RoomNo";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<ClassRoom> listOfItems = new List<ClassRoom>();
            while (sqlDataReader.Read())
            {
                ClassRoom item = new ClassRoom();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.RoomNo = sqlDataReader["RoomNo"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
           public int AllocateNewClassRoom(ClassRoomAllocation classRoomAllocation)
           {
               string query = "INSERT INTO ClassRoomAllocationTable Values('" + classRoomAllocation.TimeFrom + "','" + classRoomAllocation.TimeTo + "','0','" + classRoomAllocation.DepartmentId + "','" + classRoomAllocation.CourseId + "','" + classRoomAllocation.RoomNoId + "','" + classRoomAllocation.SevenDayWeekId + "')";
               command = new SqlCommand(query, connection);
               connection.Open();
               int rowAffect = command.ExecuteNonQuery();
               connection.Close();
               return rowAffect;
           }

           public bool IsAllocateClassRoomNotExist(ClassRoomAllocation classRoomAllocation)
           {
               string query = "SELECT *from ClassRoomAllocationTable where SevenDayWeekID ='" + classRoomAllocation.SevenDayWeekId + "' and RoomNoID ='" + classRoomAllocation.RoomNoId + "'  and Status=0 order by TimeFrom";
               command = new SqlCommand(query, connection);
               connection.Open();
               sqlDataReader = command.ExecuteReader();
               List<ClassRoomAllocation> listOfItems = new List<ClassRoomAllocation>();
               while (sqlDataReader.Read())
               {
                   ClassRoomAllocation item = new ClassRoomAllocation();
                   item.Id = Convert.ToInt32(sqlDataReader["id"]);
                   item.TimeFrom = sqlDataReader["TimeFrom"].ToString();
                   item.TimeTo = sqlDataReader["TimeTo"].ToString();
                   listOfItems.Add(item);
               }
               connection.Close();
               int[] timeArray = new int[3000];
               foreach (ClassRoomAllocation c in listOfItems)
               {
                   for (int i = Convert.ToInt32(c.TimeFrom); i <= Convert.ToInt32(c.TimeTo); i++)
                   {
                       timeArray[i] = 1;
                   }
                   timeArray[Convert.ToInt32(c.TimeTo)] = 0;
               }
               for (int i = Convert.ToInt32(classRoomAllocation.TimeFrom); i <= Convert.ToInt32(classRoomAllocation.TimeTo); i++)
               {
                   if (timeArray[i] == 1)
                   {
                       return false;
                   }
               }
               return true;
           }

    }
}