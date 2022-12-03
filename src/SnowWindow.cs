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

		private Particle[] _particles;
		private System.Drawing.Point _pastPos;
		private GameOverlay.Drawing.SolidBrush? _brush;
		private GameOverlay.Drawing.Font? _font;

		public SnowWindow()
		{
			Ins = this;

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
				FPS = Program.Settings.FPS,
				IsTopmost = true,
				IsVisible = true,
			};
			_particles = CreateParticles();

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

		private Particle[] CreateParticles()
		{
			var particles = new Particle[Program.Settings.Particles];
			for (int i = 0; i < particles.Length; i++)
			{
				particles[i] = new Particle(_window.Width, _window.Height);
			}
			return particles;
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

			var w = gfx.Width;
			var h = gfx.Height;
			for (int i = 0; i < _particles.Length; i++)
			{
				
				_particles[i].Draw(gfx, _brush);
				_particles[i].Move(w, h, cursorForce, e.DeltaTime);
			}

			//gfx.FillCircle(_brush, _pastPos.X, _pastPos.Y, 10);
		}


		public void Reload()
		{
			UpdateColor();
 			_particles = CreateParticles();
		}
		public void UpdateColor()
		{
			if (_brush != null)
				_brush.Color = new GameOverlay.Drawing.Color(Program.Settings.ParticleColor.R,
															 Program.Settings.ParticleColor.G,
															 Program.Settings.ParticleColor.B);
		}
		public void Rerandomize()
		{
			for (int i = 0; i < _particles.Length; i++)
			{
				_particles[i].RandSpeed();
			}
		}
		public void SetFPS(int fps)
		{
			_window.FPS = fps;
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
