using System.Collections.Generic;

namespace DTO.Property
{
    public class PropertyUpdateRequest
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public bool Empty { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public int Debt { get; set; }
        public int ResidentId { get; set; }
        public int VehicleId { get; set; }
        public int BillId { get; set; }
        public int RevenueId { get; set; }
    }
}
