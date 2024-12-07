namespace Shared.ValueObjects.Location;

public readonly record struct Location
{
    private const int MaxNameLength = 100;
    private static int MaxLatitude = 90;
    private static int MinLatitude = -90;
    private static int MaxLongitude = 180;
    private static int MinLongitude = -180;

    public Location(string name, double latitude, double longitude)
    {
        if (name.Length is 0)
            throw new ArgumentException("Name cannot be empty");
        if (name.Length > MaxNameLength)
            throw new ArgumentException($"Name cannot be longer than {MaxNameLength} characters");

        if (longitude > MaxLongitude || longitude < MinLongitude)
            throw new ArgumentException($"Invalid longitude");

        if (latitude > MaxLatitude || longitude < MinLatitude)
            throw new ArgumentException($"Invalid latitude");

        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    public double Latitude { get; }
    public double Longitude { get; }
}