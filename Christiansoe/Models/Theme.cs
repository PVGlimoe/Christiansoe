using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.Models
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        
        public List<Route> Routes { get; set; }
    }
}
