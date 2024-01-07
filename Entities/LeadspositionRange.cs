using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class LeadspositionRange
{
    public int Id { get; set; }

    public string? PositionName { get; set; }

    public decimal? Price { get; set; }

    public DateTime? PositionFrom { get; set; }

    public DateTime? PositionTo { get; set; }
}
