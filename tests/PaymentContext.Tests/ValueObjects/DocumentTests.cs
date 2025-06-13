using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.True(doc.Invalid);
        }

        [Fact]
        public void ShouldReturnSucessWhenCNPJIsInvalid()
        {
            var doc = new Document("34110468000150", EDocumentType.CNPJ);
            Assert.True(doc.Valid);
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123434", EDocumentType.CPF);
            Assert.True(doc.Invalid);
        }

        [Theory]
        [InlineData("10235252988")]
        [InlineData("10235252847")]
        [InlineData("10235252322")]
        public void ShouldReturnSucessWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.True(doc.Valid);
        }
    }
}
