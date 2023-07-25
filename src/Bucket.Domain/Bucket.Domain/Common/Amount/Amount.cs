namespace Bucket.Domain.Common.Amount;

public readonly record struct Amount
{
    public int Value { get; init; }
    
    public AmountUnit Unit { get; init; }

    private Amount(int value, AmountUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public static Amount operator +(Amount left, Amount right)
    {
        CheckUnits(left, right);
        return new Amount(left.Value + right.Value, left.Unit);
    }
    
    public static Amount Create(int value, AmountUnit unit) => new(value, unit);
    
    private static void CheckUnits(Amount left, Amount right)
    {
        if (left.Unit != right.Unit) throw new Exception("the left unit must match the right unit");
    }
}