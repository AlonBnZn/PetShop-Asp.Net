using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pet_Shop_Application.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [DisplayName("Comment")]
        [Required(ErrorMessage = "Please enter a comment.")]
        [MaxLength(100, ErrorMessage = "The comment cannot exceed 100 characters.")]
        public string? CommentText { get; set; }
        public int? AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }

    }
}
