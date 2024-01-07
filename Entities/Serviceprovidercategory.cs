using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovidercategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ThumnailImagePath { get; set; }

    public virtual ICollection<Cityserviceprovidercategory> Cityserviceprovidercategories { get; set; } = new List<Cityserviceprovidercategory>();

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();

    public virtual ICollection<Serviceprovidersubcategory> Serviceprovidersubcategories { get; set; } = new List<Serviceprovidersubcategory>();
}
