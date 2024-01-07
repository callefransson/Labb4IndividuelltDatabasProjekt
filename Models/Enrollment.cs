using System;
using System.Collections.Generic;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class Enrollment
{
    public int EnrollmentsId { get; set; }

    public int? FkstudentId { get; set; }

    public int? FkcourseId { get; set; }

    public int? FkgradesId { get; set; }

    public int? FkstaffId { get; set; }

    public DateTime? GradeSetDay { get; set; }

    public virtual Course? Fkcourse { get; set; }

    public virtual Grade? Fkgrades { get; set; }

    public virtual Staff? Fkstaff { get; set; }

    public virtual Student? Fkstudent { get; set; }
}
