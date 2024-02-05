using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PDF_GEN
{
	public class Dimensions
	{
        public Dimensions(int flangeOuterDiameter, int pCD, int flangeInnerDiameter, int shaftDiameter)
        {
            this.FlangeOuterDiameter = flangeOuterDiameter;
            PCD = pCD;
            this.FlangeInnerDiameter = flangeInnerDiameter;
            this.ShaftDiameter = shaftDiameter;
        }

        public int FlangeOuterDiameter { get; set; }
		public int PCD {  get;set; }
		public int FlangeInnerDiameter {  get;set; }
		public int ShaftDiameter {  get;set; }
		


	}
}
