namespace LambdaTask.Responses
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public object? Result { get; set; } 
        public int StatusCode { get; set; }
    }
}
