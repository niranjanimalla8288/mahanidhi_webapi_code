using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceproviderservice
{
    public int Id { get; set; }

    public int? ServiceProviderCategoryServicesId { get; set; }

    public int? ServiceProviderId { get; set; }

    public string? ThumnailImagePath { get; set; }

    public virtual Serviceprovider? ServiceProvider { get; set; }

    public virtual Serviceprovidercategoryservice? ServiceProviderCategoryServices { get; set; }
}
