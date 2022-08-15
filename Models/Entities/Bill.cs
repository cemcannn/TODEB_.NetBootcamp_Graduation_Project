using Models.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public BillTypeEnum Type { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public string Description { get; set; }
        public bool Paid { get; set; }
    }
}
