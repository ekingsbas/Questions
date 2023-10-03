using System.ComponentModel.DataAnnotations;

namespace Questions.Entities.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)] // Adjust the maximum length as needed
        public string Username { get; set; }

        [Required]
        [MaxLength(100)] // Adjust the maximum length as needed
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)] // Adjust the maximum length as needed
        public string Email { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }


        // Relationship with questions posted by the user
        public List<Question>? Questions { get; set; }

        // Relationship with answers provided by the user
        public List<Answer>? Answers { get; set; }

        // Relationship with votes cast by the user (optional)
        public List<Vote>? Votes { get; set; }
    }
}
