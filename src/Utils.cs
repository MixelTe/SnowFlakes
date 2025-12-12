using System.Runtime.CompilerServices;

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

		public static GameOverlay.Drawing.Color ToGameOverlayColor(this Color color)
		{
			return new GameOverlay.Drawing.Color(color.R, color.G, color.B, color.A);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float NextSingle(this Random rnd, float min, float max)
		{
			return rnd.NextSingle() * (max - min) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Wrap(this float v, float min, float max)
		{
			var range = max - min;
			float wrapped = (v - min) % range;
			if (wrapped < 0) wrapped += range;
			return wrapped + min;
		}
	}
}
