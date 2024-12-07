namespace Shared.ValueObjects.Name;

public readonly record struct Name
{
    private const int MaxLength = 50;

    public Name(string name)
    {
        if (name.Length is 0)
            throw new ArgumentException("Name cannot be empty");

        if (name.Length > MaxLength)
            throw new ArgumentException($"Name cannot be longer than {MaxLength} characters");
        
        Value = name;
    }

    public string Value { get; }

    public override string ToString() => Value;
}