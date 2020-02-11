using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class CoursesGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public CoursesGateway()
        {
            connection = new SqlConnection(conString);
        }
        public int InsertNewCourse(Course course)
        {
            string query = "INSERT INTO CourseTable Values(@CourseCode,@CourseName,@CourseCredit,@CourseDescription,@DepartmentId,@SemesterId)";
            command = new SqlCommand(query, connection);

            command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            command.Parameters["CourseCode"].Value = course.CourseCode;

            command.Parameters.Add("CourseName", SqlDbType.VarChar);
            command.Parameters["CourseName"].Value = course.CourseName;

            command.Parameters.Add("CourseCredit", SqlDbType.Decimal);
            command.Parameters["CourseCredit"].Value = course.CourseCredit;

            command.Parameters.Add("CourseDescription", SqlDbType.VarChar);
            command.Parameters["CourseDescription"].Value = course.CourseDescription;

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = course.DepartmentId;

            command.Parameters.Add("SemesterId", SqlDbType.Int);
            command.Parameters["SemesterId"].Value = course.SemesterId;

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsCodeExist(Course course)
        {
            string query = "SELECT * FROM CourseTable WHERE CourseCode = @CourseCode ";

            command = new SqlCommand(query, connection);

            command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            command.Parameters["CourseCode"].Value = course.CourseCode;


            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }
        public bool IsNameExist(Course course)
        {
            string query = "SELECT * FROM CourseTable WHERE CourseName = @CourseName ";

            command = new SqlCommand(query, connection);

            command.Parameters.Add("CourseName", SqlDbType.VarChar);
            command.Parameters["CourseName"].Value = course.CourseName;


            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }

        public List<Course> GetAllUnAssignCoursesByDeptId(int deptId)
        {
            string query = "SELECT * from CourseTable where Id not in(select CourseId from AssignTeacherTable where Status='Assign') and DepartmentID='" + deptId + "' order by CourseCode";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<Course> listOfItems = new List<Course>();
            while (sqlDataReader.Read())
            {
                Course item = new Course();
                item.Id = (int)sqlDataReader["id"];
                item.CourseCode = sqlDataReader["CourseCode"].ToString();
                item.CourseName = sqlDataReader["CourseName"].ToString();
                item.CourseCredit = (decimal)sqlDataReader["CourseCredit"];
                item.CourseDescription = sqlDataReader["CourseDescription"].ToString();
                item.DepartmentId = (int)sqlDataReader["DepartmentID"];
                item.SemesterId = (int)sqlDataReader["SemesterID"];
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
        public Course GetCourseInformationByCourseId(int courseId)
        {
            string query = "SELECT *from CourseTable where id=" + courseId + "";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            Course item = new Course();
            while (sqlDataReader.Read())
            {

                item.Id = (int)sqlDataReader["id"];
                item.CourseCode = sqlDataReader["CourseCode"].ToString();
                item.CourseName = sqlDataReader["CourseName"].ToString();
                item.CourseCredit = (decimal)sqlDataReader["CourseCredit"];
                item.CourseDescription = sqlDataReader["CourseDescription"].ToString();
                item.DepartmentId = (int)sqlDataReader["DepartmentID"];
                item.SemesterId = (int)sqlDataReader["SemesterID"];
                break;

            }
            connection.Close();
            return item;
        }
        public List<Course> GetAllCoursesByDeptId(int deptId)
        {
            string query = "SELECT *from CourseTable where DepartmentID=" + deptId + " order by CourseCode";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<Course> listOfItems = new List<Course>();
            while (sqlDataReader.Read())
            {
                Course item = new Course();
                item.Id = (int)sqlDataReader["id"];
                item.CourseCode = sqlDataReader["CourseCode"].ToString();
                item.CourseName = sqlDataReader["CourseName"].ToString();
                item.CourseCredit = (decimal)sqlDataReader["CourseCredit"];
                item.CourseDescription = sqlDataReader["CourseDescription"].ToString();
                item.DepartmentId = (int)sqlDataReader["DepartmentID"];
                item.SemesterId = (int)sqlDataReader["SemesterID"];
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }

        public List<Course> GetCourseByStudentId(string studentId)
        {
            string query = "SELECT CourseTable.id,CourseTable.CourseCode from CourseTable " +
                            "Inner JOIN DepartmentTable ON CourseTable.DepartmentID=DepartmentTable.Id " +
                            "Right JOIN StudentTable ON CourseTable.DepartmentID=StudentTable.DepartmentID where StudentTable.id='" + studentId + "' and CourseTable.id is not null";
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
        
    }
}