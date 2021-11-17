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

        public String userId { get; set; }

        public bool isMarked { get; set; } = false;

        public int position { get; set; }

        public FieldViewModel field { get; set; }
    }
}
