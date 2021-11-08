using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class UserBingoBoard
    {
    
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Done { get; set; } = false;

        [Required]
        public BingoBoard BingoBoard { get; set; }
        
        [Required]
        public String UserId { get; set; }

        public List<UserField> Fields { get; set; }
    }
}

