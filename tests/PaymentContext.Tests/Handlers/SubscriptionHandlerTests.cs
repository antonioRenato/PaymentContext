using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "First Name";
            command.LastName = "Last Name";
            command.Document = "99999999999"; // Documento já cadastrado
            command.Email = "hello@balta.io2";

            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "12345";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(5);
            command.Total = 100;
            command.TotalPaid = 100;

            command.Payer = "Payer Name";
            command.PayerDocument = "99999999999"; // Documento do pagador
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@gmail.com";

            command.Street = "Street";
            command.Number = "123";
            command.Neighborhood = "Neighborhood";
            command.City = "City";
            command.State = "State";
            command.Country = "Country";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.False(handler.Valid);
        }
    }
}
