using System.Collections.Generic;

namespace DTO.Property
{
    public class PropertyUpdateRequest
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public bool IsEmpty { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
        public int Debt { get; set; }
        public int UserId { get; set; }
    }
}
