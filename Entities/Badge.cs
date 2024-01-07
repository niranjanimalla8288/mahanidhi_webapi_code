using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Badge
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ThumnailImagePath { get; set; }

    public virtual ICollection<Serviceproviderbadge> Serviceproviderbadges { get; set; } = new List<Serviceproviderbadge>();
}
