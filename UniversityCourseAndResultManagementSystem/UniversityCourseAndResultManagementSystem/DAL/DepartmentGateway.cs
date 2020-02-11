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
    public class DepartmentGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public DepartmentGateway()
        {
            connection = new SqlConnection(conString);
        }
        public int InsertNewDepartment(Department department)
        {
            string query = "INSERT INTO DepartmentTable Values(@DeptCode, @DeptName )";
            command = new SqlCommand(query, connection);
            connection.Open();

            command.Parameters.Add("DeptCode", SqlDbType.VarChar);
            command.Parameters["DeptCode"].Value = department.DeptCode;

            command.Parameters.Add("DeptName", SqlDbType.VarChar);
            command.Parameters["DeptName"].Value = department.DeptName;


            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsCodeExist(Department department)
        {
            string query = "SELECT * FROM DepartmentTable WHERE DeptCode = @DeptCode ";

            command = new SqlCommand(query, connection);

            command.Parameters.Add("DeptCode", SqlDbType.VarChar);
            command.Parameters["DeptCode"].Value = department.DeptCode;

            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }
        public bool IsNameExist(Department department)
        {
            string query = "SELECT * FROM DepartmentTable WHERE DeptName = @DeptName ";

            command = new SqlCommand(query, connection);

            command.Parameters.Add("DeptName", SqlDbType.VarChar);
            command.Parameters["DeptName"].Value = department.DeptName;

            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }


        public List<Department> GetAllDepartments()
        {
            string query = "SELECT *from DepartmentTable order by DeptCode";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<Department> listOfItems = new List<Department>();
            while (sqlDataReader.Read())
            {
                Department item = new Department();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.DeptName = sqlDataReader["DeptName"].ToString();
                item.DeptCode = sqlDataReader["DeptCode"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }


        public string GetDepartmentCode(int deptId)
        {
            string query = "SELECT DeptCode from DepartmentTable where id='" + deptId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            string deptCode = "";
            while (sqlDataReader.Read())
            {
                deptCode = sqlDataReader["DeptCode"].ToString();
                break;

            }
            connection.Close();
            return deptCode;
        }

    
    }
}