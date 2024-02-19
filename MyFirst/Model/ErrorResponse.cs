namespace MyFirst.Model
{
    public class ErrorResponseHandler
    {
        public required int statusCode { get; init; }
        public required string statusMessage { get; init; }
    }
}
