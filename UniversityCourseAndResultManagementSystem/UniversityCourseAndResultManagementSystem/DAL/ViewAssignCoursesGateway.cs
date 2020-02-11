using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class ViewAssignCoursesGateway
    {
      
            private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            private SqlConnection connection;
            private SqlDataReader sqlDataReader;

            private SqlCommand command;

            public ViewAssignCoursesGateway()
            {
                connection = new SqlConnection(conString);
            }

            public List<ViewAssignCourse> GetAllAssignCourses(int deptId)
            {
                string query = "SELECT CourseTable.CourseCode, CourseTable.CourseName,SemesterTable.SemesterName,TeacherTable.TeacherName"
                                + " FROM AssignTeacherTable"
                                + " Right JOIN CourseTable ON CourseTable.id=AssignTeacherTable.CourseID"
                                + " LEFT JOIN TeacherTable ON TeacherTable.Id=AssignTeacherTable.TeacherID"
                                + " Inner JOIN SemesterTable ON CourseTable.SemesterID=SemesterTable.Id"
                                + " where CourseTable.DepartmentID='" + deptId + "' and AssignTeacherTable.Status='Assign' order by CourseCode";
                command = new SqlCommand(query, connection);
                connection.Open();
                sqlDataReader = command.ExecuteReader();
                List<ViewAssignCourse> listOfItems = new List<ViewAssignCourse>();
                while (sqlDataReader.Read())
                {
                    ViewAssignCourse viewAssignCourse = new ViewAssignCourse();

                    viewAssignCourse.CourseCode = sqlDataReader["CourseCode"].ToString();
                    viewAssignCourse.CourseName = sqlDataReader["CourseName"].ToString();
                    viewAssignCourse.CourseSemester = sqlDataReader["SemesterName"].ToString();
                    viewAssignCourse.AssignTeacherName = sqlDataReader["TeacherName"].ToString();
                    if (viewAssignCourse.AssignTeacherName == "")
                    {
                        viewAssignCourse.AssignTeacherName = "Not Assigned Yet";
                    }
                    listOfItems.Add(viewAssignCourse);

                }
                connection.Close();
                return listOfItems;
            }
        }
}