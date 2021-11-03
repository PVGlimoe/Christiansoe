using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class BingoBoard
    {
<<<<<<< HEAD
        private static Random rng = new Random();

=======
        [Key]
>>>>>>> ab1a550e6da45e65e015d7b7a2cadc5a0c145418
        public int Id { get; set; }


   
        private List<Field> _fields;
        public List<Field> Fields 
        {
            //Generates random images for the bingo board
            get => _fields.OrderBy(f => rng.Next()).ToList();
            set => _fields = value;
        }

        public Map Map { get; set; }

        public string Name { get; set; }


    }


}
