using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Section { get; set; }
        public bool IsEmpty { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public int Debt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Revenue> Revenues { get; set; }
    }
}
