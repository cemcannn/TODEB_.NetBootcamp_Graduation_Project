using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
