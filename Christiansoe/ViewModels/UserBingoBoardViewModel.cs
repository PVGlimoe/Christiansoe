using System;
using System.Collections.Generic;

namespace Christiansoe.ViewModels
{
    public class UserBingoBoardViewModel
    {
    
        public int Id { get; set; }

        public bool Done { get; set; } = false;

        public string Name { get; set; }

        public String userId { get; set; }

        public MapViewModel Map { get; set; }

    }
}

