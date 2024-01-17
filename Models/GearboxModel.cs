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
            double rating = 0, 
            string? type = null, 
            double number = 0, 
            double ratio = 0, 
            int poles = 0, 
            double initialRpm = 0, 
            double finalRpm = 0, 
            double torque = 0, 
            int hollowShaftDiameter = 0, 
            double fs = 0,
            int fR2 = 0,
            string? spec = null)
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
            FR2 = fR2;
            Spec = spec;
        }

        public double Rating { get; set; }
        public string? Type { get; set; }
        public double Number { get; set; }
        public double Ratio { get; set; }
        public int Poles { get; set; }
        public double InitialRpm { get; set; }
        public double FinalRpm  { get; set; }
        public double Torque { get; set; }
        public int HollowShaftDiameter { get; set; }
        public double Fs { get; set; }
        public Int32 FR2 { get; set; }
        public string? Spec { get; set; }


        public static ARWGearbox FromCSV(string csvLine) 
        {
            string[] lines = csvLine.Split(',');
            ARWGearbox gearbox = new();
            gearbox.Rating = Double.Parse(lines[0]);
            gearbox.Type = lines[1].Trim();
            gearbox.Number = Double.Parse(lines[2]);
            gearbox.Ratio = Double.Parse(lines[3]);
            gearbox.Poles = Int32.Parse(lines[4]);
            gearbox.InitialRpm = Double.Parse(lines[5]);
            gearbox.FinalRpm = Double.Parse(lines[6]);
            gearbox.Torque = Double.Parse(lines[7]); 
            gearbox.HollowShaftDiameter = Int32.Parse(lines[8]);
            gearbox.Fs = Double.Parse(lines[9]);
            gearbox.FR2 = Int32.Parse(lines[10]);
            gearbox.Spec = lines[11].Trim();
            return gearbox;
        }
    }
}
