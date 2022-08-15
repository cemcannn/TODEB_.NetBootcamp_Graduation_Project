namespace DTO.Vehicle
{
    public class VehicleInsertRequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public int OwnerId { get; set; }
    }
}
