using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? CurrencyCode { get; set; }

    public string? TelecomeCode { get; set; }

    public string? CurrencySymbol { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
