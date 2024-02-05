using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_GEN
{
	public class User
	{
		public User(string name, string designation)
		{
			Name = name;
			Designation = designation;
		}

		public string Name { get; set; }
        public string Designation { get; set; }

    }
}
