using System;
using System.Collections.Generic;

namespace Indv_DBP.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffSpecification { get; set; }

    public decimal? Salary { get; set; }

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }
}
