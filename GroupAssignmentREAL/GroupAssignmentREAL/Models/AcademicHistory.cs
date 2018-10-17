using System;
using System.Collections.Generic;

namespace GroupAssignmentREAL.Models
{
    public partial class AcademicHistory
    {
        public int Sid { get; set; }
        public string CourseId { get; set; }
        public int EnrolmentYear { get; set; }
        public int EnrolmentSemester { get; set; }
    }
}
