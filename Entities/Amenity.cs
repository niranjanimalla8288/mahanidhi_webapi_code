using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Amenity
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? Options { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();
}
