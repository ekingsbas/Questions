using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questions.Entities.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(200)] // Adjust the maximum length as needed
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)] // Adjust the maximum length as needed
        public string Body { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Relationship with the user who posted the question
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }

        // Relationship with answers to the question
        public List<Answer>? Answers { get; set; }

        // Relationship with question tags
        public List<QuestionTag>? QuestionTags { get; set; }

        // Relationship with votes on the question (optional)
        public List<Vote>? Votes { get; set; }
    }
}
