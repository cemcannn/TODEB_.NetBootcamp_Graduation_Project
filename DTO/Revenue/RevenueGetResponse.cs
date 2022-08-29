using Models.Common;
using Models.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Revenue
{
    public class RevenueGetResponse
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public MonthEnum Month { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
