using System.Text.Json.Serialization;

namespace Questions.Entities.Models
{
    public class QuestionData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("answers")]
        public List<AnswerData> Answers { get; set; }
    }
}
