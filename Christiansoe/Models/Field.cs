using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Christiansoe.Models
{
    public class Field
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Url(ErrorMessage = "Forkert billede Url")]
        public string PictureUrl { get; set; }

        [Url(ErrorMessage = "Forkert lyd Url")]
        public string SoundUrl { get; set; }

        [Url(ErrorMessage = "Forkert Video Url")]
        public string VideoUrl { get; set; }
        
        [Required]
        [Range(1,12)]
        public int StartMonth  { get; set; }

        [Required]
        [Range(1, 12)]
        public int EndMonth { get; set; }
        [Required]
        public List<BingoBoard> BingoBoards { get; set; }



    }
}
