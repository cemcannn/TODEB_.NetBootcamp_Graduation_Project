using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Section { get; set; }
        public bool Empty { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public int Debt { get; set; }
        public int ResidentId { get; set; }
        [ForeignKey("ResidentId")]
        public ICollection<Resident> Residents { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public ICollection<Vehicle> Vehicles { get; set; }
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public ICollection<Bill> Bills { get; set; }
        public int RevenueId { get; set; }
        [ForeignKey("RevenueId")]
        public ICollection<Revenue> Revenues { get; set; }
    }
}
