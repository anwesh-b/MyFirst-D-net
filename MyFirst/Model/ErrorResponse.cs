namespace MyFirst.Model
{
    public class ErrorResponseHandler
    {
        public required int statusCode { get; set; }
        public required string statusMessage { get; set; }
    }
}
