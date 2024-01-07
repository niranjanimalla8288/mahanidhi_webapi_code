using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO {

    public class CityareaDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? CityId { get; set; }

        public string? PinCode { get; set; }

        public string? Gpslocation { get; set; }

        public float? SearchRadiusInKms { get; set; }

        //public CityDTO? CityDTO { get; set; }
    }
}
