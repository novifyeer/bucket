namespace Bucket.Domain.User;

public readonly record struct UserId
{
    public int Value { get; init; }

    private UserId(int value) => Value = value;

    public static UserId Create(int value) => new(value);   
}