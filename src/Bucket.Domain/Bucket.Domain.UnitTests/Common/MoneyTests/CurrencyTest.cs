using Bucket.Domain.Common.Money;

namespace Bucket.Domain.UnitTests.Common.MoneyTests;

public class CurrencyTest
{
    public CurrencyTest () { }
    
    [Theory(DisplayName = "currency enum value should equal with ISO 4217")]
    [InlineData(Currency.Rub, 643)]
    [InlineData(Currency.Usd, 840)]
    [InlineData(Currency.Eur, 978)]
    public void CurrencyEnumValueShouldEqualIsoCurrencyCodeValue(Currency currency, int isoCode)
    {
        currency.Should().HaveValue(isoCode);
    }
}