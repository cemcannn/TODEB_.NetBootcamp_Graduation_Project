namespace DTO.Resident
{
    public class ResidentUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TRIdNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public bool Tenant { get; set; }
        public int VehicleId { get; set; }
    }
}
