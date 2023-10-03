namespace ProShop.Core;

public record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), $"Value must not be less than $0.");
        Value = Math.Round(value, 2);
    }
}
