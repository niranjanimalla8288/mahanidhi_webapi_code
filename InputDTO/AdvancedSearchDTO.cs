namespace MahaanidhiWebAPI.InputDTO
{
    public class AdvancedSearchDTO
    {
        public int StateId { get; set; } = 0;

        public int CityId { get; set; } = 0;

        public int CategoryId { get; set; } = 0;

        public string SearchString { get; set; } = "";

        //public string SearchCaluse { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public string CustomerMobile { get; set; } = string.Empty;

        public string LookingFor { get; set; } = string.Empty;

    }
}
