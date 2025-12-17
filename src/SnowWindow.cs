using GameOverlay.Windows;

namespace SnowFlakes;

public interface ISprite
{
	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx);
	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime);
	public void DestroyGraphics();
	public void Reload();
}

internal class SnowWindow : IDisposable
{
	private static readonly List<SnowWindow> _windows = [];
	private readonly GraphicsWindow _window;
	private readonly List<ISprite> _sprites = [];

	public static int Width => _windows.Count == 0 ? 0 : _windows[0]._window.Width;
	public static int Height => _windows.Count == 0 ? 0 : _windows[0]._window.Height;

	public SnowWindow()
	{
		_windows.Add(this);
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

		_window.SetupGraphics += (object? sender, SetupGraphicsEventArgs e) =>
		{
			var gfx = e.Graphics;
			_sprites.ForEach(sprite => sprite.SetupGraphics(gfx));
		};
		_window.DrawGraphics += (object? sender, DrawGraphicsEventArgs e) =>
		{
			var gfx = e.Graphics;
			gfx.ClearScene();
			_sprites.ForEach(sprite => sprite.DrawGraphics(gfx, e.DeltaTime));
		};
		_window.DestroyGraphics += (object? sender, DestroyGraphicsEventArgs e) =>
		{
			_sprites.ForEach(sprite => sprite.DestroyGraphics());
		};
	}

	~SnowWindow() { Dispose(false); }

	private bool _isDisposed;
	protected virtual void Dispose(bool disposing)
	{
		if (_isDisposed || !disposing) return;
		_isDisposed = true;
		_windows.Remove(this);
		_window.Dispose();
	}
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	public static void DisposeAll()
	{
		foreach (var w in _windows)
			w.Dispose();
		_windows.Clear();
	}
	public static void RunAll()
	{
		foreach (var w in _windows)
			w.Run();
	}
	public static void ReloadAll()
	{
		foreach (var w in _windows)
			w.Reload();
	}
	public static void SetFPSAll(int fps)
	{
		foreach (var w in _windows)
			w.SetFPS(fps);
	}

	public SnowWindow AddSprite(ISprite sprite)
	{
		_sprites.Add(sprite);
		return this;
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

	public void Run()
	{
		_window.Create();
		//_window.Join();
	}
}
