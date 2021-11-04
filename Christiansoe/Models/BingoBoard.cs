using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class BingoBoard
    {
        private static Random rng = new Random();

        [Key]
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
