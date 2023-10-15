namespace HttpExceptions
{
    public class ErrorResponse
    {
        public string ErrorId { get; set; } = Guid.NewGuid().ToString();
        public List<string>? Messages { get; set; } = new();
        public string? Source { get; set; }
        public string? Exception { get; set; }
        public int StatusCode { get; set; }
        public string? StackTrace { get; set; }
    }
}