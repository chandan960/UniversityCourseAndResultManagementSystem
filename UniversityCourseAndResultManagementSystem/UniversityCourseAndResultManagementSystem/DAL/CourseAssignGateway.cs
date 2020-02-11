using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class CourseAssignGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public CourseAssignGateway()
        {
            connection = new SqlConnection(conString);
        }
        public int AssignNewCourse(CourseAssign courseAssign)
        {
            string query = "INSERT INTO AssignTeacherTable Values('Assign','" + courseAssign.TeacherId + "','" + courseAssign.CourseId + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int UnAssignCourses()
        {
            string query = "UPDATE AssignTeacherTable SET Status = 'UnAssign' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}