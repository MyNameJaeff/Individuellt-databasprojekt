using System;
using System.Collections.Generic;

namespace Indv_DBP.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? Department { get; set; }

    public int? StaffId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Staff? Staff { get; set; }
}
