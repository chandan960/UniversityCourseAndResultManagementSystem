using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.DAL;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.BLL
{
    public class SevenDayWeekManager
    {
        private SevenDayWeekGateway sevenDayWeekGateway;

        public SevenDayWeekManager()
        {
            sevenDayWeekGateway = new SevenDayWeekGateway();
        }
        public List<SevenDayWeek> GetAllDay()
        {
            return sevenDayWeekGateway.GetAllDay();
        }
    }
}