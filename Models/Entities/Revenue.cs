using Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Revenue
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public MonthEnum Month { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
