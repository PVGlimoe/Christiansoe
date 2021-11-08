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
        [MaxLength(100)]
        public String Name { get; set; }

        public BingoBoard BingoBoard { get; set; }

        public List<Route> Routes { get; set; }

        public List<UserField> fields { get; set; }
    }
}
