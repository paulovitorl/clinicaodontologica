using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
	public class ComboItem : object
	{
		protected String Content;
		protected Int32 Value;

		public ComboItem(String name, Int32 in_value)
		{
            Content = name;
			Value = in_value;
        }
		public override int GetHashCode()
        {
			return Value;
        }
		public override string ToString()
		{
			return Content;
		}

	}
}
