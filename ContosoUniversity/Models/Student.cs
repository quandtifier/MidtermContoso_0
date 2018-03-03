using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Range(0,int.MaxValue)]
        public int? CreditsEarned { get; set; }

        [RegularExpression(@"^\d+(\.\d{0,2})?")]
        [Range(0.7,4.0)]
        public double? Gpa { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}