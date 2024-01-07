using System;
using System.Collections.Generic;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class Proffesion
{
    public int ProffesionId { get; set; }

    public string? ProffesionName { get; set; }

    public double? ProffesionSalary { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
