using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.Models
{
    public class Paths
    {
        public Paths(string gearboxOptions)
        {
            GearboxOptions = gearboxOptions;
        }

        public string GearboxOptions { get; set; }
    }
}
