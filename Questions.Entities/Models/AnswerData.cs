using System.Text.Json.Serialization;

namespace Questions.Entities.Models
{
    public  class AnswerData
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
