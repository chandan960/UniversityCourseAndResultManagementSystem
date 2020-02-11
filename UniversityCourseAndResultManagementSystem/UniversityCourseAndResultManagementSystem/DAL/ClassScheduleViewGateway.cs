using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class ClassScheduleViewGateway
    {
       
            private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            private SqlConnection connection;
            private SqlDataReader sqlDataReader;

            private SqlCommand command;

            public ClassScheduleViewGateway()
            {
                connection = new SqlConnection(conString);
            }

            public List<ClassScheduleView> GetAllClassScheduleViewsByDeptId(int deptId)
            {
                string query =
                    "SELECT CourseTable.CourseCode, CourseTable.CourseName,SevenDayWeekTable.DayShortName,ClassRoomAllocationTable.TimeFrom," +
                    " ClassRoomAllocationTable.TimeTo,ClassRoomAllocationTable.Status,ClassRoomTable.RoomName" +
                    " FROM  ClassRoomAllocationTable" +
                    " Left join SevenDayWeekTable ON SevenDayWeekTable.id=ClassRoomAllocationTable.SevenDayWeekID" +
                    " Inner join ClassRoomTable ON ClassRoomTable.id=ClassRoomAllocationTable.RoomNoID" +
                    " Right JOIN CourseTable ON CourseTable.id=ClassRoomAllocationTable.CourseID" +
                    " where CourseTable.DepartmentID='" + deptId + "' order by CourseCode";
                command = new SqlCommand(query, connection);
                connection.Open();
                sqlDataReader = command.ExecuteReader();
                List<ClassScheduleView> listOfItems = new List<ClassScheduleView>();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader["Status"].ToString() == "1")
                    {
                        continue;
                    }
                    ClassScheduleView item = new ClassScheduleView();
                    item.CourseCode = sqlDataReader["CourseCode"].ToString();
                    item.CourseName = sqlDataReader["CourseName"].ToString();
                    item.DayShortName = sqlDataReader["DayShortName"].ToString();
                    item.TimeFrom = sqlDataReader["TimeFrom"].ToString();
                    if (item.TimeFrom != "" && Convert.ToInt32(item.TimeFrom) >= 1200)
                    {
                        int temp1 = Convert.ToInt32(item.TimeFrom) - 1200;
                        string timeFrom = "";
                        if (temp1.ToString().Length == 1)
                        {
                            timeFrom = "12:00" + " PM";
                        }
                        else if (temp1.ToString().Length == 2)
                        {
                            timeFrom = "12:" + temp1 + " PM";
                        }
                        else if (temp1.ToString().Length == 3)
                        {
                            string temp = temp1.ToString();
                            char[] array = temp.ToCharArray();
                            timeFrom = "0" + array[0] + ":" + array[1] + array[2] + " PM";
                        }
                        else
                        {
                            string temp = temp1.ToString();
                            char[] array = temp.ToCharArray();
                            timeFrom = "" + array[0] + array[1] + ":" + array[2] + array[3] + " PM";
                        }
                        item.TimeFrom = timeFrom;
                    }
                    else if (item.TimeFrom != "" && Convert.ToInt32(item.TimeFrom) < 1200)
                    {
                        string temp = item.TimeFrom.ToString();
                        char[] array = temp.ToCharArray();
                        item.TimeFrom = "" + array[0] + array[1] + ":" + array[2] + array[3] + " AM";
                    }
                    item.TimeTo = sqlDataReader["TimeTo"].ToString();
                    if (item.TimeTo != "" && Convert.ToInt32(item.TimeTo) >= 1200)
                    {
                        int temp1 = Convert.ToInt32(item.TimeTo) - 1200;
                        string timeTo = "";
                        if (temp1.ToString().Length == 1)
                        {
                            timeTo = "12:00" + " PM";
                        }
                        else if (temp1.ToString().Length == 2)
                        {
                            timeTo = "12:" + temp1 + " PM";
                        }
                        else if (temp1.ToString().Length == 3)
                        {
                            string temp = temp1.ToString();
                            char[] array = temp.ToCharArray();
                            timeTo = "0" + array[0] + ":" + array[1] + array[2] + " PM";
                        }
                        else
                        {
                            string temp = temp1.ToString();
                            char[] array = temp.ToCharArray();
                            timeTo = "" + array[0] + array[1] + ":" + array[2] + array[3] + " PM";
                        }
                        item.TimeTo = timeTo;
                    }
                    else if (item.TimeTo != "" && Convert.ToInt32(item.TimeTo) < 1200)
                    {
                        string temp = item.TimeTo.ToString();
                        char[] array = temp.ToCharArray();
                        item.TimeTo = "" + array[0] + array[1] + ":" + array[2] + array[3] + " AM";
                    }
                    item.RoomName = sqlDataReader["RoomName"].ToString();
                    listOfItems.Add(item);

                }
                connection.Close();
                return listOfItems;
            }

        public int UnAllocateClassRoom()
        {
            string query = "UPDATE ClassRoomAllocationTable SET Status = '1' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}