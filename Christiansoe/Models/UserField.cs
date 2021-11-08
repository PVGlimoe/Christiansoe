using System;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class UserField
    {
    
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; }

        [Required]
        public String userId { get; set; }

        public bool isMarked { get; set; } = false;

        [Required]
        public int position { get; set; }

        [Required]
        public Field field { get; set; }

    }
}
