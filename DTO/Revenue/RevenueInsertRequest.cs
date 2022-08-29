using Models.Common;
using System;

namespace DTO.Revenue
{
    public class RevenueInsertRequest
    {
        public int Price { get; set; }
        public MonthEnum Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
