using PaymentContext.Domain.Entities.Payments;

namespace PaymentContext.Domain.Entities.PaymentsTypes
{
    public class CreditCardPayment : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}
