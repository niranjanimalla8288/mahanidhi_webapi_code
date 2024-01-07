using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Add
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public string? AddImage { get; set; }

    public string? AddPlace { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public sbyte? IsActive { get; set; }

    public virtual City? City { get; set; }
}
