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
    public class TeacherGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public TeacherGateway()
        {
            connection = new SqlConnection(conString);
        }
        public int InsertNewTeacher(Teacher teacher)
        {
            string query = "INSERT INTO TeacherTable Values(@TeacherName,@TeacherAddress,@TeacherEmail,@TeacherContactNo,@TeacherCredit,@TeacherDesignationId,@TeacherDepartmentId)";
            command = new SqlCommand(query, connection);

            command.Parameters.Add("TeacherName", SqlDbType.VarChar);
            command.Parameters["TeacherName"].Value = teacher.TeacherName;

            command.Parameters.Add("TeacherAddress", SqlDbType.VarChar);
            command.Parameters["TeacherAddress"].Value = teacher.TeacherAddress;

            command.Parameters.Add("TeacherEmail", SqlDbType.VarChar);
            command.Parameters["TeacherEmail"].Value = teacher.TeacherEmail;

            command.Parameters.Add("TeacherContactNo", SqlDbType.VarChar);
            command.Parameters["TeacherContactNo"].Value = teacher.TeacherContactNo;

            command.Parameters.Add("TeacherCredit", SqlDbType.Decimal);
            command.Parameters["TeacherCredit"].Value = teacher.TeacherCredit;

            command.Parameters.Add("TeacherDesignationId", SqlDbType.Int);
            command.Parameters["TeacherDesignationId"].Value = teacher.TeacherDesignationId;

            command.Parameters.Add("TeacherDepartmentId", SqlDbType.Int);
            command.Parameters["TeacherDepartmentId"].Value = teacher.TeacherDepartmentId;


            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsEmailExist(Teacher teacher)
        {
            string query = "SELECT * FROM TeacherTable WHERE TeacherEmail = @TeacherEmail";
            command = new SqlCommand(query, connection);

            command.Parameters.Add("TeacherEmail", SqlDbType.VarChar);
            command.Parameters["TeacherEmail"].Value = teacher.TeacherEmail;


            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }

        
          public List<Teacher> GetAllTeacherByDepartment(int departmentId)
          {
              string query = "SELECT *from TeacherTable where TeacherDepartmentID='" + departmentId + "' order by TeacherName";
              command = new SqlCommand(query, connection);
              connection.Open();
              sqlDataReader = command.ExecuteReader();
              List<Teacher> listOfItems = new List<Teacher>();
              while (sqlDataReader.Read())
              {
                  Teacher item = new Teacher();
                  item.Id = Convert.ToInt32(sqlDataReader["id"]);
                  item.TeacherName = sqlDataReader["TeacherName"].ToString();
                  item.TeacherCredit = Convert.ToDouble(sqlDataReader["TeacherCredit"]);
                  listOfItems.Add(item);
              }
              connection.Close();
              return listOfItems;
          }
          public Teacher GetTeacherInformationById(int teacherId)
          {
              string query = "SELECT *from TeacherTable where id=" + teacherId + "";
              command = new SqlCommand(query, connection);
              connection.Open();
              sqlDataReader = command.ExecuteReader();
              List<Teacher> listOfItems = new List<Teacher>();
              Teacher item = new Teacher();
              while (sqlDataReader.Read())
              {
                  item.Id = Convert.ToInt32(sqlDataReader["id"]);
                  item.TeacherName = sqlDataReader["TeacherName"].ToString();
                  item.TeacherCredit = Convert.ToDouble(sqlDataReader["TeacherCredit"]);
                  break;
              }
              connection.Close();
              return item;
          }
        
          public double GetTotalTakenCourses(int teacherId)
          {
              string query = "SELECT CourseCredit from AssignTeacherTable as AT inner join CourseTable as C on AT.CourseID=C.id where TeacherID='" + teacherId + "' and Status='Assign'";
              command = new SqlCommand(query, connection);
              double totalCredit = 0.0;
              connection.Open();
              sqlDataReader = command.ExecuteReader();
              while (sqlDataReader.Read())
              {
                  totalCredit = totalCredit  + Convert.ToDouble(sqlDataReader["CourseCredit"]);
              }
              connection.Close();
              return totalCredit;
          }
     
    }
}