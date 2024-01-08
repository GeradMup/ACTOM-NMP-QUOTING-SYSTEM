using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace NMP_Quoting_System.Models
{
    public class ARWGearboxModel
    {
        public required double Rating { get; set; }
        public required string Type { get; set; }
        public required double Number { get; set; }
        public required string Ratio { get; set; }
        public required int Poles { get; set; }
        public required double InitialRpm { get; set; }
        public required double FinalRpm  { get; set; }
        public required double Torque { get; set; }
        public required int HollowShaftDiameter { get; set; }
        public required double Fs { get; set; }
    }
}
