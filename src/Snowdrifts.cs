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
		private long DeltaTime = 0;

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
				if (Program.Settings.SnowdriftsSmooth)
				{
					var vp = _pieces[(i - 1 + _pieces.Length) % _pieces.Length];
					var v = _pieces[i];
					var vn = _pieces[(i + 1) % _pieces.Length];
					gfx.FillRectangle(brush,
						i * Program.Settings.SnowdriftsResolution,
						Height - v - Program.Settings.SnowdriftsStart,
						(i + 1) * Program.Settings.SnowdriftsResolution,
						Height - Program.Settings.SnowdriftsStart);
					if (v < vp)
						gfx.FillTriangle(brush,
							i * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - vp,
							i * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - v + 0.5f,
							(i + 0.5f) * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - v + 0.5f);
					if (v < vn)
						gfx.FillTriangle(brush,
							(i + 1) * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - vn,
							(i + 1) * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - v + 0.5f,
							(i + 0.5f) * Program.Settings.SnowdriftsResolution,
							Height - Program.Settings.SnowdriftsStart - v + 0.5f);
				}
				else
				{
					gfx.FillRoundedRectangle(brush,
						i * Program.Settings.SnowdriftsResolution,
						Height - _pieces[i] - Program.Settings.SnowdriftsStart,
						(i + 1) * Program.Settings.SnowdriftsResolution,
						Height - Program.Settings.SnowdriftsStart, 1);
				}
			}
		}
		
		public void Update(long deltaTime)
		{
			DeltaTime += deltaTime;
			if (DeltaTime < Program.Settings.SnowdriftsUpdateDelay) return;
			DeltaTime = 0;
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
			if (i >= _pieces.Length) return;
			_pieces[i] += Program.Settings.SnowdriftsSpeed;
			if (_pieces[i] > Height - Program.Settings.SnowdriftsStart)
				_pieces[i] = Height - Program.Settings.SnowdriftsStart;
		}

		public bool Intersects(float x, float y)
		{
			var i = (int)(x / Program.Settings.SnowdriftsResolution);
			if (i >= _pieces.Length) return true;
			return _pieces[i] < (Height - Program.Settings.SnowdriftsStart) / 2 && 
				   _pieces[i] + Program.Settings.SnowdriftsStart > Height - y;
		}

		public void ChangeResolution()
		{
			var pieces = new float[Width / Program.Settings.SnowdriftsResolution + 1];
			var pr = (int)(Width / (_pieces.Length - 1f));
			for (int i = 0; i < pieces.Length; i++)
			{
				var x = i * Program.Settings.SnowdriftsResolution;
				var pi = x / pr;
				pieces[i] = _pieces[pi];
			}
			_pieces = pieces;
		}

		public void AddSnow()
		{
			for (int i = 0; i < _pieces.Length; i++)
			{
				_pieces[i] += Random.Shared.NextSingle() * Height / 50;
			}
		}
	}
}
