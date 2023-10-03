using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Questions.Entities.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        [MaxLength(1000)] // Adjust the maximum length as needed
        public string Body { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Relationship with the user who posted the answer
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User? User { get; set; }

        // Relationship with the question to which this is an answer
        [Required]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        [JsonIgnore]
        public Question? Question { get; set; }

        // Relationship with votes on this answer (optional)
        public List<Vote>? Votes { get; set; }
    }
}
