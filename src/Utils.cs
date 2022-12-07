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
		public static double Noise(double x)
		{
			return 0.3 * (-3.2 * Math.Sin(-1.3 * x) - 1.2 * Math.Sin(-1.7 * Math.E * x) + 1.9 * Math.Sin(0.7 * Math.PI * x));
		}
	}
}
