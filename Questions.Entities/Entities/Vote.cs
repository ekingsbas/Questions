using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Entities.Entities
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public int Value { get; set; } // +1 for upvote, -1 for downvote

        // Relationship with the question being voted on (optional)
        public int? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        // Relationship with the answer being voted on (optional)
        public int? AnswerId { get; set; }

        [ForeignKey("AnswerId")]
        public Answer Answer { get; set; }

        // Relationship with the user who cast the vote
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
