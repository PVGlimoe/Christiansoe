using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class MapViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
