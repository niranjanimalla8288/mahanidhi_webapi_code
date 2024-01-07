using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class State
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();
}
