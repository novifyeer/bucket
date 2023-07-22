using Bucket.Domain.Common.Money;

namespace Bucket.Domain.UnitTests.Common.MoneyComplexType.Factories;

public static class MoneyFactory
{
    public static Money Create() => Money.Create(100, Currency.Usd);
}