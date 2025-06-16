using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.PaymentsTypes;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;


        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("12345678909", EDocumentType.CPF);
            _email = new Email("batman_dc@gmail.com");

            _student = new Student(_name, _document, _email);
            _address = new Address("Gotham", "Rua das Flores", "123", "Apt 1", "Bairro", "SP", "12345678");

            _subscription = new Subscription(null);
        }
        
        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubsctiption()
        {
            var payment = new PayPalPayment("123134213", DateTime.Now, DateTime.Now.AddDays(5), 
                10, 10, _document, "wayne corp", _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);
            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnSucessWhenAddSubsctiption()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10,_document, "WAYNE CORP", _address, _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            Assert.True(_student.Valid);
        }
    }
}
