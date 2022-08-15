using System;

namespace DTO.Revenue
{
    public class RevenueGetResponse
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool Paid { get; set; }
    }
}
