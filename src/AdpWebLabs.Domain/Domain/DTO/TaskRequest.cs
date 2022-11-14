using System.Text.Json.Serialization;

namespace AdpWebLabs.Domain.Domain.DTO
{
    public class TaskRequest
    {
        public TaskRequest(Guid id, double result)
        {
            Id = id;
            Result = result;
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("result")]
        public double Result { get; set; }
    }
}
