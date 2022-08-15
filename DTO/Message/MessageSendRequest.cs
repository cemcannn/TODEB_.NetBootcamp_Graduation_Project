using System;

namespace DTO.Message
{
    public class MessageSendRequest
    {
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
