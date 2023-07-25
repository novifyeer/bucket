namespace Bucket.Domain.UnitTests.Common.AmountTests;

public class AmountUnitTest
{
    public AmountUnitTest () { }
    
    [Theory(DisplayName = "amountUnit enum value should equal with ordered enum value")]
    [InlineData(AmountUnit.Unit, 0)]
    public void AmountUnitEnumValueShouldEqualOrderedEnumValue(AmountUnit amountUnit, int code)
    {
        amountUnit.Should().HaveValue(code);
    }
}