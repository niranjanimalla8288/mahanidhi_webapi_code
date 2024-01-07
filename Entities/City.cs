using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? StateId { get; set; }

    public string? Gpslocation { get; set; }

    public virtual ICollection<Add> Adds { get; set; } = new List<Add>();

    public virtual ICollection<Cityarea> Cityareas { get; set; } = new List<Cityarea>();

    public virtual ICollection<Cityserviceprovidercategory> Cityserviceprovidercategories { get; set; } = new List<Cityserviceprovidercategory>();

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();

    public virtual State? State { get; set; }
}
