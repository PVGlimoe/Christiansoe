using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class FieldViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public string SoundUrl { get; set; }

        public string VideoUrl { get; set; }
    }
}
