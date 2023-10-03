using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Questions.Entities.Entities
{
    public class QuestionTag
    {
        [Key]
        public int QuestionTagId { get; set; }

        [Required]
        [MaxLength(50)] // Adjust the maximum length as needed
        public string TagName { get; set; }

        // Relationship with the question that has this tag
        [Required]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
