using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.DAL
{
    public class SevenDayWeekGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private SqlConnection connection;
        private SqlDataReader sqlDataReader;

        private SqlCommand command;

        public SevenDayWeekGateway()
        {
            connection = new SqlConnection(conString);
        }
        public List<SevenDayWeek> GetAllDay()
        {
            string query = "SELECT *from SevenDayWeekTable order by id";
            command = new SqlCommand(query, connection);
            connection.Open();
            sqlDataReader = command.ExecuteReader();
            List<SevenDayWeek> listOfItems = new List<SevenDayWeek>();
            while (sqlDataReader.Read())
            {
                SevenDayWeek item = new SevenDayWeek();
                item.Id = Convert.ToInt32(sqlDataReader["id"]);
                item.Day = sqlDataReader["Day"].ToString();
                listOfItems.Add(item);

            }
            connection.Close();
            return listOfItems;
        }
    }
}