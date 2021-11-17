using System;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class UserField
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String UserId { get; set; }

        public bool IsMarked { get; set; } = false;

        [Required]
        public int Position { get; set; }

        [Required]
        public Field Field { get; set; }

    }
}
