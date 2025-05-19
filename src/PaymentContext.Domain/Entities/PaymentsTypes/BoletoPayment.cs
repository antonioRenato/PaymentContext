namespace PaymentContext.Domain.Entities.Payments
{
    public class BoletoPayment : Payment
    {
        public string BarCode { get; set; }
        public string  BoletoNumber { get; set; }
    }
}
