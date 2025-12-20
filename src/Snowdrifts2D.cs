using System;

namespace SnowFlakes;

class Snowdrifts2D : ISprite
{
	private static Snowdrifts2D? _instance;
	private readonly object _lock = new();
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
	private int _lastMaxHeight = 0;

	public Snowdrifts2D(int width, int height)
	{
		_instance = this;
		_screenWidth = width;
		_screenHeight = height;
		ChangeResolution();
	}
	~Snowdrifts2D()
	{
		DestroyGraphics();
	}

	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
	{
		_font?.Dispose();
		_font = gfx.CreateFont("Consolas", 30);
		_brush?.Dispose();
		_brush = gfx.CreateSolidBrush(Program.Settings.SnowdriftsColor.ToGameOverlayColor());
		_brushRects?.Dispose();
		_brushRects = gfx.CreateSolidBrush(Color.FromArgb(150, Color.Lime).ToGameOverlayColor());
	}

	public void DestroyGraphics()
	{
		_font?.Dispose(); _font = null;
		_brush?.Dispose(); _brush = null;
		_brushRects?.Dispose(); _brushRects = null;
	}

	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
	{
		if (!Program.Settings.Snowdrifts || !Program.Settings.Snowdrifts2D) return;
		lock (_lock)
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
				//SetTestForSmooth();
			}

			for (var y = 0; y < _height; y++)
				for (var x = 0; x < _width; x++)
				{
					if (!_grid[x, y]) continue;
					var x0 = x;
					do x++; while (x < _width && _grid[x, y]);
					if (Program.Settings.Snowdrifts2DSmooth)
						DrawSmooth(gfx, x0, x, y);
					else
						gfx.FillRectangle(_brush, x0 * _size, y * _size, x * _size, (y + 1) * _size);
				}

			if (Program.Settings.Snowdrifts2DBounds)
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
	}

	private void SetTestForSmooth()
	{
		_grid.SetAll(false);
		var x = 100;
		var y = 40;
		_grid[x, y] = true;

		x += 2;
		_grid[x, y + 1] = true;
		_grid[x, y] = true;

		x += 2;
		_grid[x, y - 1] = true;
		_grid[x, y] = true;

		x += 2;
		_grid[x, y + 1] = true;
		_grid[x, y - 1] = true;
		_grid[x, y] = true;

		x += 3;
		_grid[x, y + 1] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;

		x += 3;
		_grid[x, y - 1] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;

		x += 3;
		_grid[x, y + 1] = true;
		_grid[x, y - 1] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;

		x += 4;
		_grid[x, y + 1] = true;
		_grid[x - 1, y] = true;
		_grid[x, y] = true;

		x += 3;
		_grid[x, y - 1] = true;
		_grid[x - 1, y] = true;
		_grid[x, y] = true;

		x += 3;
		_grid[x, y + 1] = true;
		_grid[x, y - 1] = true;
		_grid[x - 1, y] = true;
		_grid[x, y] = true;

		y += 4;
		x -= 24;
		_grid[x, y + 1] = true;
		_grid[x - 1, y] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;

		x += 4;
		_grid[x, y - 1] = true;
		_grid[x - 1, y] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;

		x += 4;
		_grid[x, y + 1] = true;
		_grid[x, y - 1] = true;
		_grid[x - 1, y] = true;
		_grid[x + 1, y] = true;
		_grid[x, y] = true;
	}

	private void DrawSmooth(GameOverlay.Drawing.Graphics gfx, int x0, int x, int y)
	{
		if (x - x0 <= 1)
		{
			var top = y - 1 >= 0 && _grid[x0, y - 1];
			var bottom = y + 1 < _height && _grid[x0, y + 1];
			if (top && bottom)
			{
				gfx.FillTriangle(_brush,
					x0 * _size, y * _size,
					x * _size, y * _size,
					(x0 + 0.5f) * _size, (y + 0.5f) * _size
					);
				gfx.FillTriangle(_brush,
					x0 * _size, (y + 1) * _size,
					x * _size, (y + 1) * _size,
					(x0 + 0.5f) * _size, (y + 0.5f) * _size
					);
				//gfx.FillRectangle(_brush, x0 * _size, y * _size, x * _size, (y + 1) * _size);
			}
			else if (top)
			{
				gfx.FillTriangle(_brush,
					x0 * _size, y * _size,
					x * _size, y * _size,
					(x0 + 0.5f) * _size, (y + 0.5f) * _size
					);
			}
			else if (bottom)
			{
				gfx.FillTriangle(_brush,
					x0 * _size, (y + 1) * _size,
					x * _size, (y + 1) * _size,
					(x0 + 0.5f) * _size, (y + 0.5f) * _size
					);
			}
			else
			{
				gfx.FillTriangle(_brush,
					(x0 + 0.5f) * _size, (y) * _size,
					(x0 + 0.5f) * _size, (y + 1) * _size,
					x0 * _size, (y + 0.5f) * _size
					);
				gfx.FillTriangle(_brush,
					(x - 0.5f) * _size, (y) * _size,
					(x - 0.5f) * _size, (y + 1) * _size,
					x * _size, (y + 0.5f) * _size
					);
			}
			return;
		}
		gfx.FillRectangle(_brush, (x0 + 1) * _size, y * _size, (x - 1) * _size, (y + 1) * _size);

		var ltop = y - 1 >= 0 && _grid[x0, y - 1];
		var lbottom = y + 1 < _height && _grid[x0, y + 1];
		if (ltop && lbottom)
		{
			gfx.FillTriangle(_brush,
				x0 * _size, y * _size,
				(x0 + 1) * _size, y * _size,
				(x0 + 0.5f) * _size, (y + 0.5f) * _size
				);
			gfx.FillTriangle(_brush,
				x0 * _size, (y + 1) * _size,
				(x0 + 1) * _size, (y + 1) * _size,
				(x0 + 0.5f) * _size, (y + 0.5f) * _size
				);
			gfx.FillTriangle(_brush,
				(x0 + 1) * _size, (y) * _size,
				(x0 + 1) * _size, (y + 1) * _size,
				(x0 + 0.5f) * _size, (y + 0.5f) * _size
				);
			//gfx.FillRectangle(_brush, x0 * _size, y * _size, (x0 + 1) * _size, (y + 1) * _size);
		}
		else if (ltop)
		{
			gfx.FillTriangle(_brush,
				x0 * _size, y * _size,
				(x0 + 1) * _size, y * _size,
				(x0 + 1) * _size, (y + 1) * _size
				);
		}
		else if (lbottom)
		{
			gfx.FillTriangle(_brush,
				x0 * _size, (y + 1) * _size,
				(x0 + 1) * _size, (y + 1) * _size,
				(x0 + 1) * _size, y * _size
				);
		}
		else
		{
			gfx.FillTriangle(_brush,
				(x0 + 1) * _size, (y) * _size,
				(x0 + 1) * _size, (y + 1) * _size,
				(x0 + 0.5f) * _size, (y + 0.5f) * _size
				);
		}
		var rtop = y - 1 >= 0 && _grid[x - 1, y - 1];
		var rbottom = y + 1 < _height && _grid[x - 1, y + 1];
		if (rtop && rbottom)
		{
			gfx.FillTriangle(_brush,
				x * _size, y * _size,
				(x - 1) * _size, y * _size,
				(x - 0.5f) * _size, (y + 0.5f) * _size
				);
			gfx.FillTriangle(_brush,
				x * _size, (y + 1) * _size,
				(x - 1) * _size, (y + 1) * _size,
				(x - 0.5f) * _size, (y + 0.5f) * _size
				);
			gfx.FillTriangle(_brush,
				(x - 1) * _size, (y) * _size,
				(x - 1) * _size, (y + 1) * _size,
				(x - 0.5f) * _size, (y + 0.5f) * _size
				);
			//gfx.FillRectangle(_brush, (x - 1) * _size, y * _size, x * _size, (y + 1) * _size);
		}
		else if (rtop)
		{
			gfx.FillTriangle(_brush,
				x * _size, y * _size,
				(x - 1) * _size, y * _size,
				(x - 1) * _size, (y + 1) * _size
				);
		}
		else if (rbottom)
		{
			gfx.FillTriangle(_brush,
				x * _size, (y + 1) * _size,
				(x - 1) * _size, (y + 1) * _size,
				(x - 1) * _size, y * _size
				);
		}
		else
		{
			gfx.FillTriangle(_brush,
				(x - 1) * _size, (y) * _size,
				(x - 1) * _size, (y + 1) * _size,
				(x - 0.5f) * _size, (y + 0.5f) * _size
				);
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
				var bottom = Math.Min(rect.Bottom + Utils.Noise(x / 5f) * Program.Settings.Snowdrifts2DHeight / 4f, _screenHeight);
				for (var y = Math.Max(rect.Top, 0); y < bottom; y++)
					_ground[x / _size, y / _size] = true;
			}
		}
		void AddRect(Rectangle nrect)
		{
			var queue = new Queue<Rectangle>();
			var rectHeight = Math.Max(Program.Settings.Snowdrifts2DHeight, Program.Settings.Snowdrifts2DResolution);
			queue.Enqueue(new Rectangle(nrect.Left, nrect.Top, nrect.Width, rectHeight));

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

		if (src.Left < x1)
			yield return new Rectangle(src.Left, src.Top, x1 - src.Left, src.Height);

		if (x2 < src.Right)
			yield return new Rectangle(x2, src.Top, src.Right - x2, src.Height);

		if (src.Top < y1)
			yield return new Rectangle(x1, src.Top, x2 - x1, y1 - src.Top);

		if (y2 < src.Bottom)
			yield return new Rectangle(x1, y2, x2 - x1, src.Bottom - y2);
	}

	private void Update()
	{
		var maxHeightChanged = _lastMaxHeight == Program.Settings.Snowdrifts2DMaxHeight;
		_lastMaxHeight = Program.Settings.Snowdrifts2DMaxHeight;
		var movedLeftToBottom = false;
		for (var y = _height - 1; y >= 0; y--)
			for (var x = 0; x < _width; x++)
			{
				var _movedLeftToBottom = movedLeftToBottom;
				movedLeftToBottom = false;
				if (!_grid[x, y]) continue;
				if (_ground[x, y]) continue;
				if (y + 1 >= _height) _grid[x, y] = false;
				else if (y + 2 < _height && (!_grid[x, y + 1] || _movedLeftToBottom) && _grid[x, y + 2])
				{
					_grid[x, y] = false;
					_grid[x, y + 1] = true;
				}
				else if ((!_grid[x, y + 1] || _movedLeftToBottom) || (maxHeightChanged && IsFullColumn(x, y + 1)))
				{
					var r = (int)(Program.Settings.Snowdrifts2DSpeed / _size);
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
					{
						_grid[x + 1, y + 1] = true;
						movedLeftToBottom = true;
					}
				}
			}
	}

	public void Reload()
	{
		UpdateColor_();
		ChangeResolution_();
	}

	public static void UpdateColor() => _instance?.UpdateColor_();
	private void UpdateColor_()
	{
		if (_brush != null)
			_brush.Color = Program.Settings.SnowdriftsColor.ToGameOverlayColor();
	}

	public static bool AbsorbSnowflake(float x, float y) => _instance?.AbsorbSnowflake_(x, y) ?? false;
	private bool AbsorbSnowflake_(float x, float y)
	{
		if (!Program.Settings.Snowdrifts || !Program.Settings.Snowdrifts2D) return false;
		if (x < 0 || x >= _screenWidth || y < 0 || y >= _screenHeight) return false;
		lock (_lock)
		{
			var ix = (int)(x / _size);
			var iy = (int)(y / _size);
			if (ix >= _width || iy >= _height) return false;
			if (_grid[ix, iy]) return false;
			if (!(_ground[ix, iy] || (iy + 1 < _height && _grid[ix, iy + 1] && !IsFullColumn(ix, iy + 1)))) return false;
			var r = Program.Settings.Snowdrifts2DSpeed / _size / 2;
			var ir = (int)r;
			var rs = r * r;
			for (var dy = ir; dy >= -ir; dy--)
				for (var dx = -ir; dx <= ir; dx++)
				{
					var nx = ix + dx;
					var ny = iy + dy;
					if (nx >= 0 && nx < _width && ny >= 0 && ny < _height &&
						dx * dx + dy * dy < rs && 
						(_ground[nx, ny] || (ny + 1 < _height && _grid[nx, ny + 1] && !IsFullColumn(nx, ny + 1, 1))))
					{
						_grid[nx, ny] = true;
					}
				}
			return true;
		}
	}
	private bool IsFullColumn(int x, int y, int d = 0)
	{
		var noise = Utils.Noise(x / 5f) * Program.Settings.Snowdrifts2DMaxHeight / 4f;
		var v = (Program.Settings.Snowdrifts2DMaxHeight + noise) / _size;
		for (var i = 0; i < v - d; i++)
			if (y + i >= _height || _ground[x, y + i] || !_grid[x, y + i]) return false;
		return true;
	}

	public static void ChangeResolution() => _instance?.ChangeResolution_();
	private void ChangeResolution_()
	{
		lock (_lock)
		{
			var oldSize = _size;
			var oldWidth = _width;
			var oldHeight = _height;
			_size = Program.Settings.Snowdrifts2DResolution;
			_width = _screenWidth / _size;
			_height = _screenHeight / _size;
			var grid = new BitArray2D(_width, _height, false);
			var k = (float)_size / oldSize;
			if (oldSize > 0)
			for (var y = 0; y < _height; y++)
				for (var x = 0; x < _width; x++)
				{
					var ox = (int)((x + 0.5f) * k);
					var oy = (int)((y + 0.5f) * k);
					if (ox < oldWidth && oy < oldHeight)
						grid[x, y] = _grid[ox, oy];
				}
			_grid = grid;
			_ground = new(_width, _height, false);
		}
	}

	public static void AddSnow() => _instance?.AddSnow_();
	private void AddSnow_()
	{
		lock (_lock)
		for (var y = _height - 1; y >= 0; y--)
				for (var x = 0; x < _width; x++)
			{
				if ((_ground[x, y] || (y + 1 < _height && _grid[x, y + 1] && !IsFullColumn(x, y + 1, 1))))
				{
					_grid[x, y] = true;
				}
			}
	}
}
