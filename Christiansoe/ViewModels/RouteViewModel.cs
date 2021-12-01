using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.ViewModels
{
    [Serializable]
    public class RouteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public int HikingTime { get; set; }

        public string Description { get; set; }

        public int BingoBoardId { get; set; }

        public int? MapId { get; set; }

       
    }
}
