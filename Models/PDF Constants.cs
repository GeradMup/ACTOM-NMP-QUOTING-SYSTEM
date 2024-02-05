using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_GEN
{
	public static class PDF_Constants
	{
		public static readonly List<string> GeneralInfoHeaders = new List<string>
		{
			"Frame Designation:",
			"Power Rating:",
			"Output Shaft Bore:",
			"Input Shaft Bore:",
			"Specification:",
			"Mounting:"
		};

		public static readonly List<string> PerformanceHeaders = new List<string> 
		{
			"Input RPM (n1):",
			"Output RPM (n2)",
			"Ratio:",
			"Torque (Nm):",
			"Service Factor:"
		};

		public static readonly List<string> DimensionHeaders = new List<string> 
		{
			"P:",
			"M:",
			"N:",
			"D:"
		};

		public static readonly List<string> LubricantHeaders = new List<string>
		{
			"Manufacturer:",
			"Oil Type:",
			"Oil Grade:",
			"Oil Quantity"
		};

		public static readonly List<string> UserHeaders = new List<string>
		{
			"Compiler Name:",
			"Designation:",
		};

		public static readonly string LightBlue = "#8CAEDA";
		public static readonly string White = "#FEFEFF";
		public static readonly string ActomBlue = "#006CB7";
		public static readonly int FontSize = 14;
		public static readonly uint RowSpacing = 10;
		public static readonly uint ColumnSpacing = 28;
		public static readonly uint HorizontalMargins = 10;
		public static readonly string DateFormat = "yyyy/mm/dd";

	}
}
