using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class StudentResult
    {

        public int Id { get; set; }


        [Required]
        public int StudentId { get; set; }


        [Required]
        public int CourseId { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }


        [Required]
        public int GradeId { get; set; }
       
        public string Grade { get; set; }
    }
}