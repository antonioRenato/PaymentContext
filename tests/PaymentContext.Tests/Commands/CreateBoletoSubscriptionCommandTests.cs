using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    public class CreateBoletoSubscriptionCommandTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.LastName = "Silva";

            command.Validate();
            Assert.False(command.Valid);
        }
    }
}
