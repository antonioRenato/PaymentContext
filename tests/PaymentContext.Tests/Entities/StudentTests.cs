using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    public class StudentTests
    {
        [Fact]
        public void Test1()
        {
            var student = new Student("André", "teste", "231313", "antonio@gmail.com");

        }
    }
}
