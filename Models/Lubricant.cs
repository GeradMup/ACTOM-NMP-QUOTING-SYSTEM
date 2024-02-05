using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PDF_GEN
{
	public class Lubricant
	{
		public Lubricant(
			string manufacturer,
			string oilType,
			string oilGrade,
			double oilQuantity)
		{
			Manufacturer = manufacturer;
			OilType = oilType;
			OilGrade = oilGrade;
			OilQuantity = oilQuantity;
			
		}
        public string Manufacturer { get; set; }
		public string OilType { get; set;}
		public string OilGrade { get; set;}
		public double OilQuantity { get; set;}
    }
}
