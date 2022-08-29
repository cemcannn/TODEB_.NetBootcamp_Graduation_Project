using Models.Common;

namespace DTO.Bill
{
    public class BillInsertRequest
    {
        public BillTypeEnum Type { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
