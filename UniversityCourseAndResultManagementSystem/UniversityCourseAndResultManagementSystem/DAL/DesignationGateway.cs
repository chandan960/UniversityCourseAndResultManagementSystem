using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class DesignationGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public DesignationGateway()
        {
            connection = new SqlConnection(conString);
        }
        public List<TeacherDesignation> GetAllDesignations()
        {
            string query = "SELECT *from TeacherDesignationTable order by DesignationName";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<TeacherDesignation> listOfItems = new List<TeacherDesignation>();
            while (sqlDataReader.Read())
            {
                TeacherDesignation item = new TeacherDesignation();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.DesignationId = Convert.ToInt32(sqlDataReader["DesignationID"]);
                item.DesignationName = sqlDataReader["DesignationName"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
    }
}