using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceproviderbadge
{
    public int Id { get; set; }

    public int? ServiceProviderId { get; set; }

    public int? BadgeId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? IsVoid { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual Serviceprovider? ServiceProvider { get; set; }
}
