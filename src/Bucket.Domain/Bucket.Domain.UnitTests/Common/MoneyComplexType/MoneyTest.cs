using Bucket.Domain.Common.Money;

namespace Bucket.Domain.UnitTests.Common.MoneyComplexType;

public class MoneyTest
{
    public MoneyTest () { }
    
    [Fact(DisplayName = "The values passed to create a complex type must match the public properties")]
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