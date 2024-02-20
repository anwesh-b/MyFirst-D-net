namespace MyFirst.Model;

public class MongoSettings
{
    public required string ConnectionUri { get; init; }
    public required string Database { get; init; }
}