using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class PlanDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal? Cost { get; set; }

        public int? DurationInMonths { get; set; }

        public bool? IsBannerAdd { get; set; }

        public int? PositionInListing { get; set; }

        public string? ServiceDescription { get; set; }


        public ICollection<ServiceprovidersubscriptionDTO> ServiceprovidersubscriptionsDTO { get; set; } = new List<ServiceprovidersubscriptionDTO>();
    }
}