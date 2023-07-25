namespace Bucket.Domain.UnitTests.Common.AmountTests;

public class AmountTest
{
    public AmountTest () { }
    
    [Fact(DisplayName = "the values passed to create a amount strong type must match the public properties")]
    public void AmountValuesShouldMatchWithPublicProperties()
    {
        // Arrange
        const int amount = 1;
        const AmountUnit unit = AmountUnit.Unit;
        
        // Act
        var money = Amount.Create(amount, unit);
        
        // Assert
        money.Value.Should().Be(amount);
        money.Unit.Should().Be(unit);
    }
}