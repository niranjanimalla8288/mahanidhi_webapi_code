using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Cityarea
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CityId { get; set; }

    public string? PinCode { get; set; }

    public string? Gpslocation { get; set; }

    public float? SearchRadiusInKms { get; set; }

    public virtual City? City { get; set; }
}
