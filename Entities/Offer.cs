using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Offer
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public string? Title { get; set; }

    public string? LongText { get; set; }

    public string? FeaturedImage { get; set; }

    public int? HasTimeLimit { get; set; }

    public DateTime? ActivationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? PublishTime { get; set; }

    public DateTime? LastUpdatedTime { get; set; }

    public int? Status { get; set; }
}
