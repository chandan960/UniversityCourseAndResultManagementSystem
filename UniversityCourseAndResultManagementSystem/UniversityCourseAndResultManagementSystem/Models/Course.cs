﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Code must be at least five (5) characters long.")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }


        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }


        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit range is from 0.5 to 5.0")]
        [Display(Name = "Course Credit")]
        public decimal CourseCredit { get; set; }


        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }


        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }


        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
    }
}