using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Organization
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactNumber { get; set; }

    public string? SupportNumber { get; set; }

    public string? SupportEmail { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? PinCode { get; set; }

    public int? CountryId { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }
}
