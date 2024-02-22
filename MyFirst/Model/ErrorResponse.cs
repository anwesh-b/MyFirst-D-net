namespace MyFirst.Model
{
    public class ErrorResponseHandler
    {
        public required int StatusCode { get; init; }
        public required string Message { get; init; }
    }
}
