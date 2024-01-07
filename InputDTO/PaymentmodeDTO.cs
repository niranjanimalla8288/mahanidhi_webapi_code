using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO {

    public class PaymentmodeDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<ServiceprovidersubscriptionspaymentDTO> ServiceprovidersubscriptionspaymentsDTO { get; set; } = new List<ServiceprovidersubscriptionspaymentDTO>();
    }
}