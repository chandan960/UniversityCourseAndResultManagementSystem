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
    public class StudentGateway
    {
        
            private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            private SqlConnection connection;
            private SqlDataReader sqlDataReader;
    
            private SqlCommand command;

            public StudentGateway()
            {
                connection = new SqlConnection(conString);
            }
            public int InsertNewStudent(Student student)
            {
                string query = "INSERT INTO StudentTable Values(@StudentName, @StudentEmail,@StudentContactNo,@StudentAddDate,@StudentAddress,@StudentRegNo,@DepartmentId)";
                command = new SqlCommand(query, connection);

            command.Parameters.Add("StudentName", SqlDbType.VarChar);
            command.Parameters["StudentName"].Value = student.StudentName;

            command.Parameters.Add("StudentEmail", SqlDbType.VarChar);
            command.Parameters["StudentEmail"].Value = student.StudentEmail;

            command.Parameters.Add("StudentContactNo", SqlDbType.VarChar);
            command.Parameters["StudentContactNo"].Value = student.StudentContactNo;

            command.Parameters.Add("StudentAddDate", SqlDbType.VarChar);
            command.Parameters["StudentAddDate"].Value = student.StudentAddDate;

            command.Parameters.Add("StudentAddress", SqlDbType.VarChar);
            command.Parameters["StudentAddress"].Value = student.StudentAddress;

            command.Parameters.Add("StudentRegNo", SqlDbType.VarChar);
            command.Parameters["StudentRegNo"].Value = student.StudentRegNo;

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = student.DepartmentId;

            connection.Open();
                int rowAffect = command.ExecuteNonQuery();
                connection.Close();
                return rowAffect;
            }
            
            public string GetLastStudentRegNo(int deptId, string year)
            {
                string query = "SELECT TOP 1 * FROM StudentTable where DepartmentID='" + deptId + "' and StudentAddDate like '" + year + "%'  ORDER BY StudentRegNo DESC";
                command = new SqlCommand(query, connection);
                connection.Open();
                sqlDataReader = command.ExecuteReader();
                string lastRegNo = "";
                while (sqlDataReader.Read())
                {
                    lastRegNo = sqlDataReader["StudentRegNo"].ToString();
                }
                connection.Close();
                return lastRegNo;
            }
            public bool IsEmailExist(Student student)
            {
                string query = "SELECT * FROM StudentTable WHERE StudentEmail = '" + student.StudentEmail + "'";
                command = new SqlCommand(query, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                bool isExist = reader.HasRows;
                reader.Close();
                connection.Close();
                return isExist;
            }
            public List<Student> GetAllStudents()
            {
                string query = "select StudentTable.id,StudentTable.StudentRegNo, StudentTable.StudentName , StudentTable.StudentEmail,DepartmentTable.DeptCode " +
                                "from StudentTable Join DepartmentTable on StudentTable.DepartmentID=DepartmentTable.id  order by StudentRegNo";
                command = new SqlCommand(query, connection);
                connection.Open();
                sqlDataReader = command.ExecuteReader();
                List<Student> allStudent = new List<Student>();
                while (sqlDataReader.Read())
                {
                    Student item = new Student();
                    item.Id = Convert.ToInt32(sqlDataReader["id"]);
                    item.StudentRegNo = sqlDataReader["StudentRegno"].ToString();
                    item.StudentEmail = sqlDataReader["StudentEmail"].ToString();
                    item.DepartmentName = sqlDataReader["DeptCode"].ToString();
                    item.StudentName = sqlDataReader["StudentName"].ToString();
                    allStudent.Add(item);
                }
                connection.Close();
                return allStudent;
        }

            public Student GetStudentById(int studentId)
            {
                string query = "select StudentTable.id,StudentTable.StudentRegNo, StudentTable.StudentName , StudentTable.StudentEmail,DepartmentTable.DeptCode " +
                                "from StudentTable Join DepartmentTable on StudentTable.DepartmentID=DepartmentTable.id where StudentTable.id='" + studentId + "' order by StudentRegNo";
                command = new SqlCommand(query, connection);
                connection.Open();
                sqlDataReader = command.ExecuteReader();
                Student item = new Student();
                while (sqlDataReader.Read())
                {

                    item.Id = Convert.ToInt32(sqlDataReader["id"]);
                    item.StudentRegNo = sqlDataReader["StudentRegno"].ToString();
                    item.StudentEmail = sqlDataReader["StudentEmail"].ToString();
                    item.DepartmentName = sqlDataReader["DeptCode"].ToString();
                    item.StudentName = sqlDataReader["StudentName"].ToString();
                    break;
                }

                connection.Close();
                return item;
            }
            
    }
}