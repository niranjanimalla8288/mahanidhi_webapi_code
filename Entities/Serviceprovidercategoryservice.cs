using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovidercategoryservice
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ServiceProviderCategoryId { get; set; }

    public virtual ICollection<Serviceproviderservice> Serviceproviderservices { get; set; } = new List<Serviceproviderservice>();
}
