using System.Text.Json.Serialization;

namespace AdpWebLabs.Domain.Domain.DTO
{
    public class TaskResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("left")]
        public double Left { get; set; }

        [JsonPropertyName("right")]
        public double Right { get; set; }

        [JsonPropertyName("operation")]
        public string? Operation { get; set; }
    }
}
