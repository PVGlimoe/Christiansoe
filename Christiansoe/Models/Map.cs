using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Url(ErrorMessage = "Forkert Url")]
        public string Url { get; set; }



    }
}
