using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakes
{
	internal static class Utils
	{
		public static Rectangle Inflate(this Rectangle rect, int v)
		{
			return Rectangle.Inflate(rect, v, v);
		}
	}
}
