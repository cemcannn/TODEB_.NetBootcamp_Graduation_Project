using Models.Common;
using System;

namespace DTO.Bill
{
    public class BillGetResponse
    {
        public int Id { get; set; }
        public BillTypeEnum Type { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool Paid { get; set; }
    }
}
