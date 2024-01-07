using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
