namespace SnowFlakes;

internal class Snowdrifts1D : ISnowdrifts
{
	private float[] _pieces;
	private readonly int _width;
	private readonly int _height;
	private long _time = 0;
	private Point _pastCursorPos;
	private GameOverlay.Drawing.SolidBrush? _brush;

	public Snowdrifts1D(int width, int height)
	{
		_width = width;
		_height = height;

		_pieces = new float[_width / Program.Settings.SnowdriftsResolution + 1];
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

		if (!Program.Settings.Snowdrifts) return;

		Update(deltaTime, cursorForce);
		Draw(gfx);
	}

	public void DestroyGraphics()
	{
		_brush?.Dispose(); _brush = null;
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

	public void Draw(GameOverlay.Drawing.Graphics gfx)
	{
		for (int i = 0; i < _pieces.Length; i++)
		{
			if (Program.Settings.SnowdriftsSmooth)
			{
				var vp = _pieces[(i - 1 + _pieces.Length) % _pieces.Length];
				var v = _pieces[i];
				var vn = _pieces[(i + 1) % _pieces.Length];
				gfx.FillRectangle(_brush,
					i * Program.Settings.SnowdriftsResolution,
					_height - v - Program.Settings.SnowdriftsStart,
					(i + 1) * Program.Settings.SnowdriftsResolution,
					_height - Program.Settings.SnowdriftsStart);
				if (v < vp)
					gfx.FillTriangle(_brush,
						i * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - vp,
						i * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - v + 0.5f,
						(i + 0.5f) * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - v + 0.5f);
				if (v < vn)
					gfx.FillTriangle(_brush,
						(i + 1) * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - vn,
						(i + 1) * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - v + 0.5f,
						(i + 0.5f) * Program.Settings.SnowdriftsResolution,
						_height - Program.Settings.SnowdriftsStart - v + 0.5f);
			}
			else
			{
				gfx.FillRoundedRectangle(_brush,
					i * Program.Settings.SnowdriftsResolution,
					_height - _pieces[i] - Program.Settings.SnowdriftsStart,
					(i + 1) * Program.Settings.SnowdriftsResolution,
					_height - Program.Settings.SnowdriftsStart, 1);
			}
		}
	}
	
	public void Update(long deltaTime, Point? cursorForce)
	{
		_time += deltaTime;

		if (cursorForce != null)
		{
			var pos = (Point)cursorForce;
			var h = _height - Program.Settings.SnowdriftsStart - pos.Y;
			var i = (pos.X - Program.Settings.ForceD / 3) / Program.Settings.SnowdriftsResolution;
			var i2 = (pos.X + Program.Settings.ForceD / 3) / Program.Settings.SnowdriftsResolution;
			var ic = pos.X / Program.Settings.SnowdriftsResolution;
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
						if (v > nv)
							_pieces[i] = v;
						else
							_pieces[i] = nv;
					}
					if (_pieces[i] < 0) _pieces[i] = 0;
				}
				i++;
			}
		}

		if (_time < Program.Settings.SnowdriftsUpdateDelay) return;
		_time = 0;
		for (int i = 0; i < _pieces.Length; i++)
		{
			var pi = (i - 1 + _pieces.Length) % _pieces.Length;
			var ni = (i + 1) % _pieces.Length;
			var v = _pieces[i];
			var density = Program.Settings.SnowdriftsDensity * Program.Settings.SnowdriftsResolution / 2;
			var d1 = _pieces[pi] - v - density;
			if (d1 > 0)
			{
				_pieces[pi] -= d1 / 2f;
				_pieces[i] += d1 / 2f;
			}
			var d2 = _pieces[ni] - v - density;
			if (d2 > 0)
			{
				_pieces[ni] -= d2 / 2f;
				_pieces[i] += d2 / 2f;
			}
		}
	}

	public bool AbsorbSnowflake(float x, float y)
	{
		var i = (int)(x / Program.Settings.SnowdriftsResolution);
		if (i < 0 || i >= _pieces.Length) return false;
		if (_pieces[i] >= (_height - Program.Settings.SnowdriftsStart) / 2 ||
			_pieces[i] + Program.Settings.SnowdriftsStart <= _height - y)
			return false;
		_pieces[i] += Program.Settings.SnowdriftsSpeed / Program.Settings.SnowdriftsResolution;
		_pieces[i] = Math.Min(_pieces[i], _height - Program.Settings.SnowdriftsStart);
		return true;
	}

	public void ChangeResolution()
	{
		var pieces = new float[_width / Program.Settings.SnowdriftsResolution + 1];
		var pr = (int)(_width / (_pieces.Length - 1f));
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
			_pieces[i] += Random.Shared.NextSingle() * _height / 50;
		}
	}
	public void CreateSmooth()
	{
		var m = _height / 35;
		for (int i = 0; i < _pieces.Length; i++)
		{
			_pieces[i] = (float)(Utils.Noise(i / 100d * Program.Settings.SnowdriftsResolution) * m + m * 4);
			if (_pieces[i] < 0) _pieces[i] = 0;
		}
	}
}
