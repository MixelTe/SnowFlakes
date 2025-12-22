namespace SnowFlakes;

internal class Snowdrifts1D : ISprite
{
	private static Snowdrifts1D? _instance;
	private readonly object _lock = new();
	private float[] _pieces;
	private readonly int _width;
	private readonly int _height;
	private long _time = 0;
	private Point _pastCursorPos;
	private GameOverlay.Drawing.SolidBrush? _brush;

	public Snowdrifts1D(int width, int height)
	{
		_instance = this;
		_width = width;
		_height = height;

		_pieces = new float[_width / Program.Settings.Snowdrifts1DResolution + 1];
	}
	~Snowdrifts1D()
	{
		DestroyGraphics();
	}

	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
	{
		_brush?.Dispose();
		_brush = gfx.CreateSolidBrush(Program.Settings.SnowdriftsColor.ToGameOverlayColor());
	}

	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
	{
		Point? cursorForce = _pastCursorPos != Cursor.Position ? Cursor.Position : null;
		_pastCursorPos = Cursor.Position;

		if (!Program.Settings.Snowdrifts || !Program.Settings.Snowdrifts1D) return;

		if (Program.Settings.Snowdrifts1DAutoStart)
			Program.Settings.Snowdrifts1DStart = Utils.GetTaskBarBottomHeight();

		lock (_lock)
		{
			Update(deltaTime, cursorForce);
			Draw(gfx);
		}
	}

	public void DestroyGraphics()
	{
		_brush?.Dispose(); _brush = null;
	}

	public void Reload()
	{
		UpdateColor_();
		ChangeResolution_();
	}

	public void Draw(GameOverlay.Drawing.Graphics gfx)
	{
		for (int i = 0; i < _pieces.Length; i++)
		{
			if (Program.Settings.Snowdrifts1DSmooth)
			{
				var vp = _pieces[(i - 1 + _pieces.Length) % _pieces.Length];
				var v = _pieces[i];
				var vn = _pieces[(i + 1) % _pieces.Length];
				gfx.FillRectangle(_brush,
					i * Program.Settings.Snowdrifts1DResolution,
					_height - v - Program.Settings.Snowdrifts1DStart,
					(i + 1) * Program.Settings.Snowdrifts1DResolution,
					_height - Program.Settings.Snowdrifts1DStart);
				if (v < vp)
					gfx.FillTriangle(_brush,
						i * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - vp,
						i * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - v,
						(i + 0.5f) * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - v);
				if (v < vn)
					gfx.FillTriangle(_brush,
						(i + 1) * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - vn,
						(i + 1) * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - v,
						(i + 0.5f) * Program.Settings.Snowdrifts1DResolution,
						_height - Program.Settings.Snowdrifts1DStart - v);
			}
			else
			{
				gfx.FillRectangle(_brush,
					i * Program.Settings.Snowdrifts1DResolution,
					_height - _pieces[i] - Program.Settings.Snowdrifts1DStart,
					(i + 1) * Program.Settings.Snowdrifts1DResolution,
					_height - Program.Settings.Snowdrifts1DStart);
			}
		}
	}
	
	public void Update(long deltaTime, Point? cursorForce)
	{
		_time += deltaTime;

		if (cursorForce != null)
		{
			var pos = (Point)cursorForce;
			var h = _height - Program.Settings.Snowdrifts1DStart - pos.Y;
			var i = (pos.X - Program.Settings.ForceD / 3) / Program.Settings.Snowdrifts1DResolution;
			var i2 = (pos.X + Program.Settings.ForceD / 3) / Program.Settings.Snowdrifts1DResolution;
			var ic = pos.X / Program.Settings.Snowdrifts1DResolution;
			if (i < 0) i = 0;
			if (i2 < 0) i2 = 0;
			if (i >= _pieces.Length) i = _pieces.Length - 1;
			if (i2 >= _pieces.Length) i2 = _pieces.Length - 1;
			var m = Math.Abs(ic - i2);
			while (i <= i2)
			{
				if (_pieces[i] >= h - Program.Settings.ForcePower)
				{
					var nv = h - Program.Settings.ForcePower * ((m - Math.Abs(i - ic) + 0f) / m);
					if (nv < _pieces[i])
					{
						var v = _pieces[i] - Program.Settings.ForcePower / 2;
						_pieces[i] = v > nv ? v : nv;
					}
					if (_pieces[i] < 0) _pieces[i] = 0;
				}
				i++;
			}
		}

		if (_time < 100) return;
		_time = 0;

		var k = 0.5f;
		var density = Program.Settings.Snowdrifts1DDensity * Program.Settings.Snowdrifts1DResolution * 0.1f;
		var r = 1 - (int)Math.Log2(Math.Min(Program.Settings.Snowdrifts1DResolution, 150) / 150f);
		for (int _ = 0; _ < r; _++)
		for (int i = 0; i < _pieces.Length; i++)
		{
			var pi = (i - 1 + _pieces.Length) % _pieces.Length;
			var ni = (i + 1) % _pieces.Length;

			var pd = Math.Max(0, _pieces[i] - _pieces[pi] - density);
			var nd = Math.Max(0, _pieces[i] - _pieces[ni] - density);

			_pieces[i] -= (pd + nd) * k;
			_pieces[pi] += pd * k;
			_pieces[ni] += nd * k;
		}
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
		if (!Program.Settings.Snowdrifts || !Program.Settings.Snowdrifts1D) return false;
		lock (_lock)
		{
			var i = (int)(x / Program.Settings.Snowdrifts1DResolution);
			if (i < 0 || i >= _pieces.Length) return false;
			var noise = (float)Utils.Noise((i + 0.5) / 100d * Program.Settings.Snowdrifts1DResolution) * _height / 50;
			if (_pieces[i] >= (_height - Program.Settings.Snowdrifts1DStart) / 2 + noise ||
				_pieces[i] + Program.Settings.Snowdrifts1DStart <= _height - y)
				return false;
			_pieces[i] += Program.Settings.Snowdrifts1DSpeed / Program.Settings.Snowdrifts1DResolution;
			_pieces[i] = Math.Min(_pieces[i], _height - Program.Settings.Snowdrifts1DStart);
			return true;
		}
	}

	public static void ChangeResolution() => _instance?.ChangeResolution_();
	private void ChangeResolution_()
	{
		lock (_lock)
		{
			var pieces = new float[_width / Program.Settings.Snowdrifts1DResolution + 1];
			var pr = (int)(_width / (_pieces.Length - 1f));
			for (int i = 0; i < pieces.Length; i++)
			{
				var x = i * Program.Settings.Snowdrifts1DResolution;
				var pi = x / pr;
				pieces[i] = _pieces[pi.Wrap(0, _pieces.Length)];
			}
			_pieces = pieces;
		}
	}

	public static void AddSnow() => _instance?.AddSnow_();
	private void AddSnow_()
	{
		lock (_lock)
		{
			var m = _height / 50;
			var t = Random.Shared.Next();
			for (int i = 0; i < _pieces.Length; i++)
				_pieces[i] += (float)((Utils.Noise((i + t) / 100d * Program.Settings.Snowdrifts1DResolution) + 2) * m);
		}
	}

	public static void CreateSmooth() => _instance?.CreateSmooth_();
	private void CreateSmooth_()
	{
		lock (_lock)
		{
			var m = _height / 35;
			for (int i = 0; i < _pieces.Length; i++)
			{
				_pieces[i] = (float)(Utils.Noise((i + 0.5) / 100d * Program.Settings.Snowdrifts1DResolution) * m + m * 4);
				if (_pieces[i] < 0) _pieces[i] = 0;
			}
		}
	}
}
