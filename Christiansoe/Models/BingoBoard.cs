using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class BingoBoard
    {
        [Key]
        public int Id { get; set; }

        public List<Field> Fields { get; set; }

        public Map Map { get; set; }

        public string Name { get; set; }





    }
}
