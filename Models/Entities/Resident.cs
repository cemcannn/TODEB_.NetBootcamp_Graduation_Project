using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TRIdNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public bool Tenant { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
