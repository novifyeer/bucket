namespace Bucket.Domain.Common.Money;

public readonly record struct Money
{
    public decimal Value { get; init; }
    public Currency Currency { get; init; }

    private Money(decimal value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Money Create(decimal value, Currency currency) => new(value, currency);
}