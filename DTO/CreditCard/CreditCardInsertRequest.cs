namespace DTO.CreditCard
{
    public class CreditCardInsertRequest
    {
        public string UserName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string CVV { get; set; }
    }
}
