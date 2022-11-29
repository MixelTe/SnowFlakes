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
			return new(
				rect.X - v,
				rect.Y - v,
				rect.Width + v * 2,
				rect.Height + v * 2
				);
		}
	}
}
