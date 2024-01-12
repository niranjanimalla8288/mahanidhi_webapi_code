using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? MobileNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? LoginOtp { get; set; }

    public virtual ICollection<Serviceproviderreview> Serviceproviderreviews { get; set; } = new List<Serviceproviderreview>();
}
