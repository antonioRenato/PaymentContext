using PaymentContext.Domain.Entities.Payments;

namespace PaymentContext.Domain.Entities.PaymentsTypes
{
    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; set; }
    }
}   
