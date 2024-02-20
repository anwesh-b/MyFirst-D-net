namespace MyFirst.Model
{
    public class ErrorResponseHandler
    {
        public required int StatusCode { get; init; }
        public required string StatusMessage { get; init; }
    }
}
