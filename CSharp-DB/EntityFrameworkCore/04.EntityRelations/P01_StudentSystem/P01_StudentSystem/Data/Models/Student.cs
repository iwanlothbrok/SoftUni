using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new List<StudentCourse>();
            this.HomeworkSubmissions = new List<Homework>();
        }
        public int StudentId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }
        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }



    }
}
//⦁	studentid
//⦁	name(up to 100 characters, unicode)
//⦁	phonenumber(exactly 10 characters, not unicode, not required)
//⦁	registeredon
//⦁	birthday(not required)
