using System;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class Field
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public string SoundUrl { get; set; }

        public string VideoUrl { get; set; }

        public int StartMonth  { get; set; }
        public int EndMonth { get; set; }


    }
}
