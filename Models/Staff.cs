using System;
using System.Collections.Generic;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffFirstName { get; set; }

    public string? StaffLastName { get; set; }

    public string? StaffSsn { get; set; }

    public int? StaffAge { get; set; }

    public string? StaffSex { get; set; }

    public int? FkproffesionId { get; set; }

    public DateTime? StaffStartDate { get; set; }

    public int? FkclassId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Class? Fkclass { get; set; }

    public virtual Proffesion? Fkproffesion { get; set; }
}
