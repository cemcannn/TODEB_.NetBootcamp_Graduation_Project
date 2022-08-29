using Business.Configuration.Response;
using DTO.Payment;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        public CommandResponse PayBill(PayBillRequest request);
    }
}
