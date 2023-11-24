namespace aksesuarcim.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? image { get; set; }
        public IFormFile? ResimYukle { get; set; }
    }
}