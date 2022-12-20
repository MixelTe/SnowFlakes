using System;
using System.Collections.Generic;
using System.Text;

using GameOverlay.Drawing;
using GameOverlay.Windows;
using SnowFlakes.Properties;

namespace SnowFlakes
{
	internal class SnowWindow : IDisposable
	{
		private readonly GraphicsWindow _window;

		private Particle[] _particles;
		public Snowdrifts Snowdrifts;
		private System.Drawing.Point _pastPos;
		private bool _updateSnowflakeImg = false;
		private GameOverlay.Drawing.SolidBrush? _brush;
		private GameOverlay.Drawing.SolidBrush? _brushSnowdrifts;
		private GameOverlay.Drawing.Font? _font;
		public GameOverlay.Drawing.Image? Snowflake0;
		public GameOverlay.Drawing.Image? Snowflake1;
		public GameOverlay.Drawing.Image? Snowflake2;

		public SnowWindow()
		{
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
			
			Snowdrifts = new Snowdrifts(_window.Width, _window.Height);

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
			_brushSnowdrifts?.Dispose();
			Snowflake0?.Dispose();
			Snowflake1?.Dispose();
			Snowflake2?.Dispose();

			_brush = gfx.CreateSolidBrush(Program.Settings.ParticleColor.R,
										  Program.Settings.ParticleColor.G,
										  Program.Settings.ParticleColor.B,
										  Program.Settings.ParticleColor.A);

			_brushSnowdrifts = gfx.CreateSolidBrush(Program.Settings.SnowdriftsColor.R,
													Program.Settings.SnowdriftsColor.G,
													Program.Settings.SnowdriftsColor.B,
													Program.Settings.SnowdriftsColor.A);

			TryCreateImg(gfx);

			var ic = new ImageConverter();
			var img1 = (byte[]?)ic.ConvertTo(Resources.snowflake_simple, typeof(byte[]));
			Snowflake1 = gfx.CreateImage(img1);

			var img2 = (byte[]?)ic.ConvertTo(Resources.snowflake, typeof(byte[]));
			Snowflake2 = gfx.CreateImage(img2);

			if (e.RecreateResources) return;

			_font = gfx.CreateFont("Consolas", 14);
		}
		private void TryCreateImg(GameOverlay.Drawing.Graphics gfx)
		{
			if (Program.Settings.ParticleImgPath != "")
			{
				try
				{
					Snowflake0?.Dispose();
					Snowflake0 = gfx.CreateImage(Program.Settings.ParticleImgPath);
				}
				catch
				{
					Program.Settings.ParticleImgPath = "";
					Program.Settings.ParticleImg = -1;
				}
			}
		}

		private void DestroyGraphics(object? sender, DestroyGraphicsEventArgs e)
		{
			_brush?.Dispose();
		}

		private void DrawGraphics(object? sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;
			if (_updateSnowflakeImg)
			{
				_updateSnowflakeImg = false;
				TryCreateImg(gfx);
			}

			//var padding = 16;
			//var infoText = new StringBuilder()
			//	.Append("FPS: ").Append(gfx.FPS.ToString().PadRight(padding))
			//	.Append("FrameTime: ").Append(e.FrameTime.ToString().PadRight(padding))
			//	.Append("FrameCount: ").Append(e.FrameCount.ToString().PadRight(padding))
			//	.Append("DeltaTime: ").Append(e.DeltaTime.ToString().PadRight(padding))
			//	.ToString();

			gfx.ClearScene();

			//gfx.DrawText(_font, _brush, 58, 20, infoText);

			System.Drawing.Point? cursorForce = _pastPos != Cursor.Position ? Cursor.Position : null;
			_pastPos = Cursor.Position;

			if (Program.Settings.Snowdrifts)
			{
				Snowdrifts.Update(e.DeltaTime, cursorForce);
				Snowdrifts.Draw(gfx, _brushSnowdrifts);
			}

			var w = gfx.Width;
			var h = gfx.Height;
			for (int i = 0; i < _particles.Length; i++)
			{
				
				_particles[i].Draw(gfx, _brush);
				if (i >= _particles.Length || _particles[i] == null) break;
				if (e.DeltaTime < 1000)
					_particles[i].Move(w, h, cursorForce, e.DeltaTime);
			}

			//gfx.FillCircle(_brush, _pastPos.X, _pastPos.Y, 10);
		}


		public void Reload()
		{
			UpdateColor();
			UpdateColorSnowdrifts();
 			_particles = CreateParticles();
			Snowdrifts.ChangeResolution();
		}
		public void UpdateColor()
		{
			if (_brush != null)
				_brush.Color = new GameOverlay.Drawing.Color(Program.Settings.ParticleColor.R,
															 Program.Settings.ParticleColor.G,
															 Program.Settings.ParticleColor.B,
															 Program.Settings.ParticleColor.A);
		}
		public void UpdateColorSnowdrifts()
		{
			if (_brushSnowdrifts != null)
				_brushSnowdrifts.Color = new GameOverlay.Drawing.Color(Program.Settings.SnowdriftsColor.R,
																	   Program.Settings.SnowdriftsColor.G,
																	   Program.Settings.SnowdriftsColor.B,
																	   Program.Settings.SnowdriftsColor.A);
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
		public void UpdateSnowflakeImg()
		{
			_updateSnowflakeImg = true;
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
