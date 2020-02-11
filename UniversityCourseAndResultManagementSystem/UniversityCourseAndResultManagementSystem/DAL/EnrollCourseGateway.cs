using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class EnrollCourseGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public EnrollCourseGateway()
        {
            connection = new SqlConnection(conString);
        }

        public int EnrollNewCourseToStudent(EnrollInCourse enrollInCourse)
        {
            string query = "INSERT INTO AssignStudentTable Values('0','" + enrollInCourse.Date + "','" + enrollInCourse.StudentId + "','" + enrollInCourse.CourseId + "','10')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsCourseIdAndStudentIdExist(EnrollInCourse enrollInCourse)
        {
            string query = "SELECT * FROM AssignStudentTable WHERE CourseID = '" + enrollInCourse.CourseId + "' And StudentID='" + enrollInCourse.StudentId + "' AND Status='0'";

            command = new SqlCommand(query, connection);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }

        public int DisEnrollCourses()
        {
            string query = "UPDATE AssignStudentTable SET Status = '1' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}