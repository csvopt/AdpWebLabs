using System.Text.Json.Serialization;

namespace AdpWebLabs.Domain.Domain.DTO
{
    public class TaskSubmitRequest
    {
        public TaskSubmitRequest(Guid id, double result)
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
