using System;
using System.Collections.Generic;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string CourseStatus { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
