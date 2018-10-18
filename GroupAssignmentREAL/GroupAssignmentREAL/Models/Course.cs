using System;
using System.Collections.Generic;

namespace GroupAssignmentREAL.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrolment = new HashSet<Enrolment>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public string Semester { get; set; }
        public string PreRequisites { get; set; }
        public string Compulsory { get; set; }

        public ICollection<Enrolment> Enrolment { get; set; }
    }
}
