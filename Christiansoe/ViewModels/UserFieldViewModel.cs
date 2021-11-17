using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class UserFieldViewModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public string SoundUrl { get; set; }

        public string VideoUrl { get; set; }

        public String UserId { get; set; }

        public bool IsMarked { get; set; } = false;

        public int Position { get; set; }
    }
}
