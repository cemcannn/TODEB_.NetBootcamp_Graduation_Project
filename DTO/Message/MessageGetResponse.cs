using System;

namespace DTO.Message
{
    public class MessageGetResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
    }
}
