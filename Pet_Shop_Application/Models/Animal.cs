using System.ComponentModel.DataAnnotations;

namespace Pet_Shop_Application.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(20)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The Age need to be between [0-150] and required.")]
        [Range(0, 150)]
        public int Age { get; set; }
        [Required]
        public string? PictureName { get; set; }
        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(350)]
        public string? Description { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        [Required]
        [Range(1, 4)]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }


    }
}
