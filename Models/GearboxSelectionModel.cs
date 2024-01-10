using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace NMP_Quoting_System.Models
{
    public class ARWGearbox
    {
        public ARWGearbox(
            double rating, 
            string type, 
            double number, 
            double ratio, 
            int poles, 
            double initialRpm, 
            double finalRpm, 
            double torque, 
            int hollowShaftDiameter, 
            double fs)
        {
            Rating = rating;
            Type = type;
            Number = number;
            Ratio = ratio;
            Poles = poles;
            InitialRpm = initialRpm;
            FinalRpm = finalRpm;
            Torque = torque;
            HollowShaftDiameter = hollowShaftDiameter;
            Fs = fs;
        }

        public double Rating { get; set; }
        public string Type { get; set; }
        public double Number { get; set; }
        public double Ratio { get; set; }
        public int Poles { get; set; }
        public double InitialRpm { get; set; }
        public double FinalRpm  { get; set; }
        public double Torque { get; set; }
        public int HollowShaftDiameter { get; set; }
        public double Fs { get; set; }
    }
}
