using System.ComponentModel.DataAnnotations;

namespace Pet_Shop_Application.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }

    }
}
