using System.Collections;

namespace SnowFlakes;

class Snowdrifts2D : ISnowdrifts
{
	private readonly VirtualDesktopManager _vdm = new();
	private readonly int _screenWidth;
	private readonly int _screenHeight;
	private int _size;
	private int _width;
	private int _height;
	private BitArray2D _grid = new(0, 0);
	private BitArray2D _ground = new(0, 0);
	private GameOverlay.Drawing.Font? _font;
	private GameOverlay.Drawing.SolidBrush? _brush;
	private GameOverlay.Drawing.SolidBrush? _brushRects;
	private long _timeElapsedFromGround = 0;
	private long _timeElapsedFromUpdate = 0;

	public Snowdrifts2D(int width, int height)
	{
		_screenWidth = width;
		_screenHeight = height;
		ChangeResolution();
	}

	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
	{
		_font?.Dispose();
		_font = gfx.CreateFont("Consolas", 30);
		_brush?.Dispose();
		_brush = gfx.CreateSolidBrush(Program.Settings.SnowdriftsColor.ToGameOverlayColor());
		_brushRects?.Dispose();
		_brushRects = gfx.CreateSolidBrush(Color.Lime.ToGameOverlayColor());
	}

	public void DestroyGraphics()
	{
		_font?.Dispose(); _font = null;
		_brush?.Dispose(); _brush = null;
		_brushRects?.Dispose(); _brushRects = null;
	}

	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
	{
		_timeElapsedFromGround += deltaTime;
		if (_timeElapsedFromGround > 100)
		{
			_timeElapsedFromGround = 0;
			UpdateGround();
		}

		_timeElapsedFromUpdate += deltaTime;
		if (_timeElapsedFromUpdate > 50)
		{
			_timeElapsedFromUpdate = 0;
			Update();
		}

		for (var y = 0; y < _height; y++)
			for (var x = 0; x < _width; x++)
			{
				if (!_grid[x, y]) continue;
				var x0 = x;
				do x++; while (x < _width && _grid[x, y]);
				gfx.FillRectangle(_brush, x0 * _size, y * _size, x * _size, (y + 1) * _size);
			}

		var drawGroundBounds = true;
		if (drawGroundBounds)
			for (var y = 0; y < _height; y++)
				for (var x = 0; x < _width; x++)
				{
					if (!_ground[x, y]) continue;
					if (x - 1 >= 0 && _ground[x - 1, y] &&
						y - 1 >= 0 && _ground[x, y - 1] &&
						x + 1 < _width && _ground[x + 1, y] &&
						y + 1 < _height && _ground[x, y + 1]) continue;
					gfx.FillRectangle(_brushRects, x * _size, y * _size, (x + 1) * _size, (y + 1) * _size);
				}
	}

	private void UpdateGround()
	{
		if (Control.ModifierKeys.ToString() == "Alt" || Control.ModifierKeys == (Keys.Control | Keys.Alt))
			return;

		var wrects = new List<Rectangle>();
		var rects = new List<Rectangle>();
		foreach (var window in OpenWindowGetter.GetOpenWindows())
		{
			if (!_vdm.IsWindowOnCurrentVirtualDesktop(window.Key)) continue;
			if (window.Value.Item1.Contains("ShareX")) continue;
			if (window.Value.Item1.Contains("Переключение задач")) continue;
			if (window.Value.Item1.Contains("Task Switcher")) continue;
			AddRect(window.Value.Item2);
		}
		_ground.SetAll(false);
		foreach (var rect in rects)
		{
			if (rect.Top < 32) continue;
			var right = Math.Min(rect.Right, _screenWidth);
			for (var x = Math.Max(rect.Left, 0); x < right; x++)
			{
				var bottom = Math.Min(rect.Bottom + Utils.Noise(x / _size) * _size, _screenHeight);
				for (var y = Math.Max(rect.Top, 0); y < bottom; y++)
					_ground[x / _size, y / _size] = true;
			}
		}
		void AddRect(Rectangle nrect)
		{
			var queue = new Queue<Rectangle>();
			queue.Enqueue(new Rectangle(nrect.Left, nrect.Top, nrect.Width, 16));

			while (queue.Count > 0)
			{
				var r = queue.Dequeue();
				if (r.Top < 10) continue;
				bool split = false;

				foreach (var wrect in wrects)
				{
					if (!r.IntersectsWith(wrect))
						continue;

					foreach (var piece in Split(r, wrect))
						queue.Enqueue(piece);

					split = true;
					break;
				}

				if (!split)
					rects.Add(r);
			}
			wrects.Add(nrect);
		}
	}
	private static IEnumerable<Rectangle> Split(Rectangle src, Rectangle cut)
	{
		int x1 = Math.Max(src.Left, cut.Left);
		int y1 = Math.Max(src.Top, cut.Top);
		int x2 = Math.Min(src.Right, cut.Right);
		int y2 = Math.Min(src.Bottom, cut.Bottom);

		if (x1 >= x2 || y1 >= y2)
		{
			yield return src;
			yield break;
		}

		if (src.Top < y1)
			yield return new Rectangle(src.Left, src.Top, src.Width, y1 - src.Top);

		if (y2 < src.Bottom)
			yield return new Rectangle(src.Left, y2, src.Width, src.Bottom - y2);

		if (src.Left < x1)
			yield return new Rectangle(src.Left, y1, x1 - src.Left, y2 - y1);

		if (x2 < src.Right)
			yield return new Rectangle(x2, y1, src.Right - x2, y2 - y1);
	}

	private void Update()
	{
		for (var y = _height - 1; y >= 0; y--)
			for (var x = 0; x < _width; x++)
			{
				if (!_grid[x, y]) continue;
				if (_ground[x, y]) continue;
				if (y + 1 >= _height) _grid[x, y] = false;
				else if (!_grid[x, y + 1])
				{
					var r = Program.Settings.ParticleRad / _size;
					var rs = r * r;
					for (var dy = -r; dy <= r; dy++)
						for (var dx = -r; dx <= r; dx++)
						{
							var nx = x + dx;
							var ny = y + dy;
							if (nx >= 0 && nx < _width && ny >= 0 && ny < _height &&
								dx * dx + dy * dy <= rs)
							{
							 	_grid[nx, ny] = false;
							}
						}
					Snowflakes.AddTo(x * _size, y * _size);
				}
				else
				{
					var hasLeft = x - 1 < 0 || _grid[x - 1, y + 1];
					var hasRight = x + 1 >= _width || _grid[x + 1, y + 1];
					if (hasLeft && hasRight) continue;
					_grid[x, y] = false;
					if (hasRight || (!hasLeft && !hasRight && Random.Shared.Next(0, 2) == 0))
						_grid[x - 1, y + 1] = true;
					else
						_grid[x + 1, y + 1] = true;
				}
			}
	}

	public void Reload()
	{
		UpdateColor();
		ChangeResolution();
	}

	public void UpdateColor()
	{
		if (_brush != null)
			_brush.Color = Program.Settings.SnowdriftsColor.ToGameOverlayColor();
	}

	public bool AbsorbSnowflake(float x, float y)
	{
		if (x < 0 || x >= _screenWidth || y < 0 || y >= _screenHeight) return false;
		var ix = (int)(x / _size);
		var iy = (int)(y / _size);
		if (_grid[ix, iy]) return false;
		if (!_ground[ix, iy] && !(iy + 1 < _height && _grid[ix, iy + 1])) return false;
		if (isFullColumn(ix, iy + 1)) return false;
		var r = Program.Settings.SnowdriftsSpeed / _size / 2;
		var ir = (int)r;
		var rs = r * r;
		for (var dy = -ir; dy <= ir; dy++)
			for (var dx = -ir; dx <= ir; dx++)
			{
				var nx = ix + dx;
				var ny = iy + dy;
				if (nx >= 0 && nx < _width && ny >= 0 && ny < _height &&
					dx * dx + dy * dy < rs)
				{
					_grid[nx, ny] = true;
				}
			}
		return true;

		bool isFullColumn(int x, int y)
		{
			for (var i = 0; i < 32 / _size; i++)
				if (y + i >= _height || !_grid[x, y + i]) return false;
			return true;
		}
	}

	public void ChangeResolution()
	{
		_size = Program.Settings.SnowdriftsResolution;
		_width = _screenWidth / _size;
		_height = _screenHeight / _size;
		_grid = new(_width, _height, false);
		_ground = new(_width, _height, false);
	}

	public void AddSnow()
	{
	}

	public void CreateSmooth()
	{
	}
}
