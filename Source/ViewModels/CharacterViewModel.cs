using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CharacterViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string gender { get; set; }
        public string origin { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string location { get; set; }
    }
}
