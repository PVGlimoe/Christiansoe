using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.Models
{
    public class Theme
    {

        public int Id { get; set; }
        public String Name { get; set; }

        public List<Route> Routes { get; set; }
    }
}
