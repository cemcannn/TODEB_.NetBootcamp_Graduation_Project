using Models.Entities;
using System.Collections.Generic;

namespace DTO.Property
{
    public class PropertyGetResponse
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public bool IsEmpty { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public int Debt { get; set; }
        public Models.Entities.User User { get; set; }
        public ICollection<Models.Entities.Bill> Bills { get; set; }
        public ICollection<Models.Entities.Revenue> Revenues { get; set; }
    }
}