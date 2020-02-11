using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class StudentResultGateway
    {
       
            private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            private SqlConnection connection;
            private SqlDataReader sqlDataReader;

            private SqlCommand command;

            public StudentResultGateway()
            {
                connection = new SqlConnection(conString);
            }

        public List<GradeLetter> GetAllGrades()
        {
            string query = "SELECT *from GradeTable order  by id";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<GradeLetter> listOfItems = new List<GradeLetter>();
            while (sqlDataReader.Read())
            {
                GradeLetter item = new GradeLetter();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.Grade = sqlDataReader["Grade"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
        public List<Course> GetAllTakenCourses(int studentId)
        {
            string query = "SELECT CourseTable.CourseCode,CourseTable.id from AssignStudentTable " +
                            "Inner JOIN CourseTable ON CourseTable.id=AssignStudentTable.CourseID " +
                            "where AssignStudentTable.StudentID='" + studentId + "' and AssignStudentTable.Status=0";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<Course> listOfItems = new List<Course>();
            while (sqlDataReader.Read())
            {
                Course item = new Course();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.CourseCode = sqlDataReader["CourseCode"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }

        public int SaveAResult(StudentResult studentResult)
        {
            string query = "UPDATE AssignStudentTable SET GradeId = '" + studentResult.GradeId + "' where StudentID ='" + studentResult.StudentId + "' AND CourseID='" + studentResult.CourseId + "' AND Status ='0'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public List<StudentResult> GetAllResultByStudentId(int studentId)
        {
            string query = "SELECT CourseTable.CourseCode,CourseTable.CourseName,GradeTable.Grade from AssignStudentTable " +
                            "Inner JOIN CourseTable ON CourseTable.id=AssignStudentTable.CourseID " +
                            "Inner JOIN GradeTable On AssignStudentTable.GradeID=GradeTable.id " +
                            "where AssignStudentTable.StudentID='" + studentId + "' and AssignStudentTable.Status=0";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<StudentResult> listOfItems = new List<StudentResult>();
            while (sqlDataReader.Read())
            {
                StudentResult item = new StudentResult();
                item.CourseCode = sqlDataReader["CourseCode"].ToString();
                item.CourseName = sqlDataReader["CourseName"].ToString();
                item.Grade = sqlDataReader["Grade"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
    }
}