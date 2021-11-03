using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }



    }
}
