using System;
using System.Collections.Generic;

namespace GroupAssignmentREAL.Models
{
    public partial class Enrolment
    {
        public int EnrolId { get; set; }
        public string CourseId { get; set; }
        public string CourseDescription { get; set; }
        public int EnrolmentYear { get; set; }
        public int EnrolmentSemester { get; set; }
        public string PreRequisite { get; set; }

        public Course Course { get; set; }
    }
}
