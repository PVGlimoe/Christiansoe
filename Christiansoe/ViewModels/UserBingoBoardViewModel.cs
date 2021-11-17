using Christiansoe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class UserBingoBoardViewModel
    {
        public int Id { get; set; }

        public MapViewModel? Map{ get; set; }

        public string Name { get; set; }

        public bool Done { get; set; }

        public string UserId { get; set; }

    }
}
