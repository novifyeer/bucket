using Bucket.Domain.Common.Money;

namespace Bucket.Domain.UnitTests.Common.MoneyTests;

public class MoneyTest
{
    public MoneyTest () { }
    
    [Fact(DisplayName = "the values passed to create a money complex type must match the public properties")]
    public void MoneyValuesShouldMatchWithPublicProperties()
    {
        // Arrange
        const int price = 100;
        const Currency currency = Currency.Usd;
        
        // Act
        var money = Money.Create(price, currency);
        
        // Assert
        money.Value.Should().Be(price);
        money.Currency.Should().Be(currency);
    }
}