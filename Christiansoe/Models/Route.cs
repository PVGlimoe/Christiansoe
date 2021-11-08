using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0,20)]
        public double Length { get; set; }
        [Required]
        [Range(1,300)]
        public int HikingTime { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        public BingoBoard BingoBoard { get; set; }

        public Map Map { get; set; }







    }
}
