using System;
using System.Collections.Generic;
using System.Text;

using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace SnowFlakes
{
	internal class SnowWindow : IDisposable
	{
		internal static SnowWindow? Ins;
		private readonly GraphicsWindow _window;

		private Particle[] _points;
		private System.Drawing.Point _pastPos;
		private GameOverlay.Drawing.SolidBrush? _brush;
		private GameOverlay.Drawing.Font? _font;

		public SnowWindow()
		{
			Ins = this;
			_points = Array.Empty<Particle>();

			var gfx = new GameOverlay.Drawing.Graphics()
			{
				MeasureFPS = true,
				PerPrimitiveAntiAliasing = true,
				TextAntiAliasing = true
			};

			_window = new GraphicsWindow(gfx)
			{
				X = 0,
				Y = 0,
				Width = Screen.PrimaryScreen.Bounds.Width,
				Height = Screen.PrimaryScreen.Bounds.Height,
				FPS = 60,
				//IsTopmost = true,
				IsVisible = true,
			};

			_window.SetupGraphics += SetupGraphics;
			_window.DrawGraphics += DrawGraphics;
			_window.DestroyGraphics += DestroyGraphics;
		}
		~SnowWindow()
		{
			Dispose(false);
		}
		public void Run()
		{
			_window.Create();
			//_window.Join();
		}

		private void SetupGraphics(object? sender, SetupGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			_brush?.Dispose();
			_brush = gfx.CreateSolidBrush(Program.Settings.ParticleColor.R,
										  Program.Settings.ParticleColor.G,
										  Program.Settings.ParticleColor.B);

			if (e.RecreateResources) return;

			_font = gfx.CreateFont("Consolas", 14);
		}

		private void DestroyGraphics(object? sender, DestroyGraphicsEventArgs e)
		{
			_brush?.Dispose();
		}

		private void DrawGraphics(object? sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			var padding = 16;
			var infoText = new StringBuilder()
				.Append("FPS: ").Append(gfx.FPS.ToString().PadRight(padding))
				.Append("FrameTime: ").Append(e.FrameTime.ToString().PadRight(padding))
				.Append("FrameCount: ").Append(e.FrameCount.ToString().PadRight(padding))
				.Append("DeltaTime: ").Append(e.DeltaTime.ToString().PadRight(padding))
				.ToString();

			gfx.ClearScene();

			gfx.DrawText(_font, _brush, 58, 20, infoText);

			System.Drawing.Point? cursorForce = _pastPos != Cursor.Position ? Cursor.Position : null;
			_pastPos = Cursor.Position;

			//for (int i = 0; i < _points.Length; i++)
			//{
			//	//e.Graphics.DrawEllipse(Pens.LightBlue, new Rectangle((int)_points[i].X, (int)_points[i].Y, 10, 10));
			//	_points[i].Draw(e.Graphics, _brush);
			//	_points[i].Move(Width, Height, cursorForce);
			//}

			//e.Graphics.DrawEllipse(Pens.LightGreen, new Rectangle(Cursor.Position, new Size(10, 10)));
			//base.OnPaint(e);
		}


		public void Reload()
		{
			//_brush = new SolidBrush(Program.Settings.ParticleColor);
			//_points = new Particle[Program.Settings.Particles];
			//for (int i = 0; i < _points.Length; i++)
			//{
			//	_points[i] = new Particle(Width, Height);
			//}
		}
		public void UpdateColor()
		{
			//_brush = new SolidBrush(Program.Settings.ParticleColor);
		}
		public void Rerandomize()
		{
			//for (int i = 0; i < _points.Length; i++)
			//{
			//	_points[i].RandSpeed();
			//}
		}

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				_window.Dispose();

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
