namespace Alefba.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
