using System;
using System.Collections.Generic;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentFirstName { get; set; }

    public string? StudentLastName { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public string? StudentEmail { get; set; }

    public int? FkclassId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Class? Fkclass { get; set; }
}
