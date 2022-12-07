using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakes
{
	internal class Snowdrifts
	{
		private float[] _pieces;
		private readonly int Width;
		private readonly int Height;

		public Snowdrifts(int width, int height)
		{
			Width = width;
			Height = height;

			_pieces = new float[Width / Program.Settings.SnowdriftsResolution + 1];
		}

		public void Draw(GameOverlay.Drawing.Graphics gfx, GameOverlay.Drawing.SolidBrush? brush)
		{
			for (int i = 0; i < _pieces.Length; i++)
			{
				gfx.FillRoundedRectangle(brush,
					i * Program.Settings.SnowdriftsResolution,
					Height - _pieces[i] - Program.Settings.SnowdriftsStart,
					(i + 1) * Program.Settings.SnowdriftsResolution,
					Height - Program.Settings.SnowdriftsStart, 1);
			}
		}
		
		public void Update(long deltaTime)
		{
			for (int i = 0; i < _pieces.Length; i++)
			{
				var pi = (i - 1 + _pieces.Length) % _pieces.Length;
				var ni = (i + 1) % _pieces.Length;
				var v = _pieces[i];
				var d1 = _pieces[pi] - v - Program.Settings.SnowdriftsDensity;
				if (d1 > 0)
				{
					_pieces[pi] -= d1 / 2f;
					_pieces[i] += d1 / 2f;
				}
				var d2 = _pieces[ni] - v - Program.Settings.SnowdriftsDensity;
				if (d2 > 0)
				{
					_pieces[ni] -= d2 / 2f;
					_pieces[i] += d2 / 2f;
				}
			}
		}

		public void Add(float x)
		{
			var i = (int)(x / Program.Settings.SnowdriftsResolution);
			_pieces[i] += Program.Settings.SnowdriftsSpeed;
			if (_pieces[i] > Height - Program.Settings.SnowdriftsStart)
				_pieces[i] = Height - Program.Settings.SnowdriftsStart;
		}
		public bool Intersects(float x, float y)
		{
			var i = (int)x / Program.Settings.SnowdriftsResolution;
			return _pieces[i] < (Height - Program.Settings.SnowdriftsStart) / 2 && 
				   _pieces[i] + Program.Settings.SnowdriftsStart > Height - y;
		}
	}
}
