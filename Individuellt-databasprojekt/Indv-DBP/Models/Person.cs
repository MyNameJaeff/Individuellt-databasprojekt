using System;
using System.Collections.Generic;

namespace Indv_DBP.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalNumber { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public string Role { get; set; } = null!;

    public virtual Staff? Staff { get; set; }

    public virtual Student? Student { get; set; }
}
