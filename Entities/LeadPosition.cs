using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class LeadPosition
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public int? CategoryId { get; set; }

    public int? LeadpositionRangeId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? ServiceProviderId { get; set; }
}
