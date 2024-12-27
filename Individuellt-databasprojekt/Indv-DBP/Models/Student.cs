using System;
using System.Collections.Generic;

namespace Indv_DBP.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int PersonId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Person Person { get; set; } = null!;
}
