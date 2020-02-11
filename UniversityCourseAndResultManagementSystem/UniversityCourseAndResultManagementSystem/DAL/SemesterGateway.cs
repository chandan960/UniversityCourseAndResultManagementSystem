using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class SemesterGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public SemesterGateway()
        {
            connection = new SqlConnection(conString);
        }
        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * from SemesterTable order by SemesterCode";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<Semester> listOfItems = new List<Semester>();
            while (sqlDataReader.Read())
            {
                Semester item = new Semester();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.SemesterCode = Convert.ToInt32(sqlDataReader["SemesterCode"]);
                item.SemesterName = sqlDataReader["SemesterName"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
    }
}