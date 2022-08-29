using Models.Common;

namespace DTO.Bill
{
    public class BillGetResponse
    {
        public int Id { get; set; }
        public BillTypeEnum Type { get; set; }
        public int Price { get; set; }
        public MonthEnum Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
