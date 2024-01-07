using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceproviderbusinesstag
{
    public int Id { get; set; }

    public int? ServiceProviderId { get; set; }

    public int? BusinessTagId { get; set; }

    public virtual Businesstag? BusinessTag { get; set; }

    public virtual Serviceprovider? ServiceProvider { get; set; }
}
