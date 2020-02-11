using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Teacher
    {

        public int Id { get; set; }


        [Required]
        [Display(Name = "Name")]
        public string TeacherName { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string TeacherAddress { get; set; }


        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string TeacherEmail { get; set; }


        [Required]
        [RegularExpression(@"^\(?[+. ]?([0-9]{2})\)?[-. ]?([0-9]{11})$", ErrorMessage = "Invalid Phone number(e.+8801XXXXXXXXX)")]
        [Display(Name = "Contact No")]
        public string TeacherContactNo { get; set; }


        [Required]
        [Display(Name = "Designation")]
        public int TeacherDesignationId { get; set; }


        [Required]
        [Display(Name = "Department")]
        public int TeacherDepartmentId { get; set; }


        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Credit must be a Postive Number")]
        [Display(Name = "Credit to be taken")]
        public double TeacherCredit { get; set; }

        public double CourseTaken { get; set; }
    }
}