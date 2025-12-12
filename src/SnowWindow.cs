using GameOverlay.Windows;

namespace SnowFlakes
{
	public interface ISprite
	{
		public void SetupGraphics(GameOverlay.Drawing.Graphics gfx);
		public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime);
		public void DestroyGraphics();
		public void Reload();
	}

	internal class SnowWindow : IDisposable
	{
		private readonly GraphicsWindow _window;
		private readonly List<ISprite> _sprites = [];

		public Snowflakes Snowflakes;
		public Snowdrifts Snowdrifts;
		public ChristmasLights ChristmasLights;

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
				Width = Screen.PrimaryScreen?.Bounds.Width ?? 0,
				Height = Screen.PrimaryScreen?.Bounds.Height ?? 0,
				FPS = Program.Settings.FPS,
				IsTopmost = true,
				IsVisible = true,
			};

			_sprites.Add(Snowflakes = new Snowflakes(_window.Width, _window.Height));
			_sprites.Add(Snowdrifts = new Snowdrifts(_window.Width, _window.Height));
			_sprites.Add(ChristmasLights = new ChristmasLights(_window.Width, _window.Height));
			_sprites.Add(new SnowFps());

			_window.SetupGraphics += SetupGraphics;
			_window.DrawGraphics += DrawGraphics;
			_window.DestroyGraphics += DestroyGraphics;
		}

		~SnowWindow()
		{
			Dispose(false);
		}

		private bool _isDisposed;
		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed || !disposing) return;
			_isDisposed = true;
			_window.Dispose();
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Run()
		{
			_window.Create();
			//_window.Join();
		}

		private void SetupGraphics(object? sender, SetupGraphicsEventArgs e)
		{
			var gfx = e.Graphics;
			_sprites.ForEach(sprite => sprite.SetupGraphics(gfx));
		}

		private void DestroyGraphics(object? sender, DestroyGraphicsEventArgs e)
		{
			_sprites.ForEach(sprite => sprite.DestroyGraphics());
		}

		private void DrawGraphics(object? sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;
			gfx.ClearScene();
			_sprites.ForEach(sprite => sprite.DrawGraphics(gfx, e.DeltaTime));
		}

		public void Reload()
		{
			_window.FPS = Program.Settings.FPS;
			_sprites.ForEach(sprite => sprite.Reload());
		}

		public void SetFPS(int fps)
		{
			_window.FPS = fps;
		}
	}
}
