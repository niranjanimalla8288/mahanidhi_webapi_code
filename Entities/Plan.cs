using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Plan
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Cost { get; set; }

    public int? DurationInMonths { get; set; }

    public bool? IsBannerAdd { get; set; }

    public int? PositionInListing { get; set; }

    public string? ServiceDescription { get; set; }

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();

    public virtual ICollection<Serviceprovidersubscription> Serviceprovidersubscriptions { get; set; } = new List<Serviceprovidersubscription>();
}
