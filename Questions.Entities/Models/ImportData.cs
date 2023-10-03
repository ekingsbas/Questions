using System.Text.Json.Serialization;

namespace Questions.Entities.Models
{
    public class ImportData
    {
        [JsonPropertyName("questions")]
        public List<QuestionData> Questions { get; set; }
    }
}
