using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SnowFlakes;

internal static class Utils
{
	public static Rectangle Inflate(this Rectangle rect, int v)
	{
		return Rectangle.Inflate(rect, v, v);
	}
	public static bool IntersectsWith(this Rectangle rect, float x, float y)
	{
		return rect.X + rect.Width >= x && x >= rect.X && 
			   rect.Y + rect.Height >= y && y >= rect.Y;
	}
	public static int GetTaskBarBottomHeight()
	{
		if (Screen.PrimaryScreen == null) return 0;
		var wa = Screen.PrimaryScreen.WorkingArea;
		if (wa.Left > 0) return 0;
		if (wa.Top > 0) return 0;
		if (wa.Width < Screen.PrimaryScreen.Bounds.Width) return 0;
		return Screen.PrimaryScreen.Bounds.Height - wa.Height;
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
	public static T RandomItem<T>(this IList<T> values)
	{
		return values[Random.Shared.Next(values.Count)];
	}
	public static T RandomItem<T>(this T[] values)
	{
		return values[Random.Shared.Next(values.Length)];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Wrap(this float v, float min, float max)
	{
		var range = max - min;
		var wrapped = (v - min) % range;
		if (wrapped < 0) wrapped += range;
		return wrapped + min;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Wrap(this int v, int min, int max)
	{
		var range = max - min;
		var wrapped = (v - min) % range;
		if (wrapped < 0) wrapped += range;
		return wrapped + min;
	}

	public static bool IsValidRegex(string pattern)
	{
		if (string.IsNullOrWhiteSpace(pattern)) return false;

		try
		{
			Regex.Match("", pattern);
		}
		catch (ArgumentException)
		{
			return false;
		}

		return true;
	}
}

public class BitArray2D(int width, int height, bool defaultValue = false)
{
	private readonly BitArray _arr = new(width * height, defaultValue);

	public bool this[int x, int y]
	{
		get => _arr.Get(x + y * width);
		set => _arr.Set(x + y * width, value);
	}

	public void SetAll(bool value) => _arr.SetAll(value);

	public bool GetSafe(int x, int y)
	{
		if (x < 0 || x > width || y < 0 || y > height) return false;
		return this[x, y];
	}
}