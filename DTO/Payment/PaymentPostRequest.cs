namespace DTO.Payment
{
    public class PaymentPostRequest
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int BillId { get; set; }
        public int RevenuesId { get; set; }
    }
}
