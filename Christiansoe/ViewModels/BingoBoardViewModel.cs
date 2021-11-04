using Christiansoe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class BingoBoardViewModel
    {
        public int Id { get; set; }
        public MapViewModel Map{ get; set; }
        public string Name { get; set; }
    }
}
