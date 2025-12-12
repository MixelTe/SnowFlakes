namespace SnowFlakes;

internal class ChristmasLights : ISprite
{
	private readonly int _width;
	private readonly int _height;
	private int _interval = 0;
	private float _speed = 1;
	private Light[] _lights = [];
	private LightsMode _mode;
	private GameOverlay.Drawing.SolidBrush? _brush;

	public ChristmasLights(int width, int height)
	{
		_width = width;
		_height = height;
		UpdateInterval();
		UpdateSpeed();
		_mode = GetCurLightsMode();
	}

	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
	{
		_brush?.Dispose();
		_brush = gfx.CreateSolidBrush(255, 0, 0);
	}

	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
	{
		if (!Program.Settings.ChristmasLights) return;
		_mode.Update(_lights, (int)Math.Round(deltaTime * _speed));

		if (_brush == null) return;
		for (int i = 0; i < _lights.Length; i++)
		{
			var d = i * _interval;
			var x = 0; var y = 0;
			if (d < _height) y = _height - d;
			else if (d < _height + _width) x = d - _height;
			else { x = _width; y = d - _height - _width; }

			var radius = Program.Settings.ChristmasLightsRadius;
			var step = radius > 20 ? 2 : 1;
			_brush.Color = _lights[i].ToColor(radius / step);
			for (int j = 0; j < radius; j += step)
				gfx.FillCircle(_brush, x, y, j);
		}
	}

	public void DestroyGraphics()
	{
		_brush?.Dispose(); _brush = null;
	}

	public void Reload()
	{
		UpdateInterval();
		UpdateMode();
		UpdateSpeed();
	}

	private LightsMode GetCurLightsMode()
	{
		return Program.Settings.ChristmasLightsMode switch
		{
			1 => new LightsMode_Waving(),
			2 => new LightsMode_Steping(),
			3 => new LightsMode_Blinking(),
			4 => new LightsMode_Running(),
			_ => new LightsMode_Mix(),
		};
	}

	public void UpdateInterval()
	{
		_interval = Program.Settings.ChristmasLightsInterval;
		var lights = new Light[(_width + _height * 2) / _interval];
		for (int i = 0; i < lights.Length; i++)
		{
			lights[i] = new Light(Random.Shared.Next(255), Random.Shared.Next(255), Random.Shared.Next(255));
		}
		_lights = lights;
		_mode = GetCurLightsMode();
	}
	public void UpdateMode()
	{
		_mode = GetCurLightsMode();
	}
	public void UpdateSpeed()
	{
		var speed = Program.Settings.ChristmasLightsAnimationSpeed;
		_speed = speed >= 100 ? speed / 100f : 0.5f + speed / 200f;
	}

	private class Light(int r, int g, int b, int a = 255)
	{
		public int R = r;
		public int G = g;
		public int B = b;
		public int A = a;
		public int V1;

		public void Set(int r, int g, int b, int a = 255, int v1 = 0)
		{
			R = r;
			G = g;
			B = b;
			A = a;
			V1 = v1;
		}

		public GameOverlay.Drawing.Color ToColor(int drawSteps)
		{
			//var m = 2 - (A / 256f);
			//var a = (int)Math.Min(Math.Max(A * m, 0), 255);
			return new GameOverlay.Drawing.Color(R, G, B, A / drawSteps);
		}
	}

	private abstract class LightsMode
	{
		private bool _started = false;
		protected abstract void Start(Light[] lights);
		protected abstract void UpdateLights(Light[] lights, int deltaTime);
		public void Update(Light[] lights, int deltaTime)
		{
			if (!_started)
			{
				_started = true;
				Start(lights);
			}
			UpdateLights(lights, deltaTime);
		}
	}

	private class LightsMode_Waving : LightsMode
	{
		protected override void Start(Light[] lights)
		{
			for (int i = 0; i < lights.Length; i++)
			{
				var light = lights[i];
				switch (i % 4)
				{
					case 0: light.Set(255, 0, 0, 0, 1); break;
					case 1: light.Set(0, 255, 0, 128, 1); break;
					case 2: light.Set(0, 0, 255, 255, -1); break;
					case 3: light.Set(255, 255, 0, 128, -1); break;
				}
			}
		}

		protected override void UpdateLights(Light[] lights, int deltaTime)
		{
			foreach (var light in lights)
			{
				light.A += deltaTime / 5 * light.V1;
				if (light.A > 255)
				{
					light.A = 255;
					light.V1 = -1;
				}
				else if (light.A < 0)
				{
					light.A = 0;
					light.V1 = 1;
				}
			}
		}
	}

	private class LightsMode_Steping : LightsMode
	{
		private int _time = 0;
		private int _timeInterval = 500;
		private int _timeIntervalD = 10;
		private int _curI = 0;

		private void SetLights(Light[] lights)
		{
			for (int i = 0; i < lights.Length; i++)
			{
				var light = lights[i];
				switch (i % 4)
				{
					case 0: light.Set(255, 0, 0, _curI == 0 ? 255 : 0); break;
					case 1: light.Set(0, 255, 0, _curI == 1 ? 255 : 0); break;
					case 2: light.Set(0, 0, 255, _curI == 2 ? 255 : 0); break;
					case 3: light.Set(255, 255, 0, _curI == 3 ? 255 : 0); break;
				}
			}
		}

		protected override void Start(Light[] lights)
		{
			SetLights(lights);
		}

		protected override void UpdateLights(Light[] lights, int deltaTime)
		{
			_time += deltaTime;
			_timeInterval += _timeIntervalD * deltaTime / 50;
			if (_timeInterval > 1000) _timeIntervalD = -5;
			if (_timeInterval < 500) _timeIntervalD = 5;
			if (_time > _timeInterval)
			{
				_time = 0;
				_curI = (_curI + 1) % 4;
				SetLights(lights);
			}
		}
	}
	
	private class LightsMode_Blinking : LightsMode
	{
		private int _time = 0;
		private int _timeInterval = 100;
		private int _curI = 0;

		private void SetLights(Light[] lights)
		{
			for (int i = 0; i < lights.Length; i++)
			{
				var light = lights[i];
				switch (i % 4)
				{
					case 0: light.Set(255, 0, 0, _curI == 0 ? 255 : 0); break;
					case 1: light.Set(0, 255, 0, _curI == 1 ? 255 : 0); break;
					case 2: light.Set(0, 0, 255, _curI == 0 ? 255 : 0); break;
					case 3: light.Set(255, 255, 0, _curI == 1 ? 255 : 0); break;
				}
			}
		}

		protected override void Start(Light[] lights)
		{
			SetLights(lights);
		}

		protected override void UpdateLights(Light[] lights, int deltaTime)
		{
			_time += deltaTime;
			int i = _time / _timeInterval % 8;
			if (_curI != i)
			{
				if (i < 4)
				{
					_curI = i % 2 == 0 ? 0 : 10;
				}
				else
				{
					_curI = i % 2 == 0 ? 1 : 10;
				}
				SetLights(lights);
			}
		}
	}
	
	private class LightsMode_Running : LightsMode
	{
		private int _time = 0;

		protected override void Start(Light[] lights)
		{
			for (int i = 0; i < lights.Length; i++)
			{
				var light = lights[i];
				switch (i % 4)
				{
					case 0: light.Set(255, 0, 0, 0); break;
					case 1: light.Set(0, 255, 0, 0); break;
					case 2: light.Set(0, 0, 255, 0); break;
					case 3: light.Set(255, 255, 0, 0); break;
				}
			}
		}

		protected override void UpdateLights(Light[] lights, int deltaTime)
		{
			_time += deltaTime;
			for (int i = 0; i < lights.Length; i++)
			{
				var light = lights[i];
				light.A = (int)Math.Clamp(Fn(i) * 255, 0, 255);
			}
		}

		private float Fn(int i)
		{
			return (float)(Math.Sin((_time / 100f + i) * 0.7) + 1) / 2;
		}
	}

	private class LightsMode_Mix : LightsMode
	{
		private readonly int _interval = 30000;
		private int _time = 0;
		private int _modeI = 0;
		private LightsMode _mode = new LightsMode_Waving();

		protected override void Start(Light[] lights) { }

		private void RunNextMode()
		{
			_modeI = (_modeI + 1) % 4;
			_mode = _modeI switch
			{
				0 => new LightsMode_Waving(),
				1 => new LightsMode_Steping(),
				2 => new LightsMode_Blinking(),
				3 => new LightsMode_Running(),
				_ => new LightsMode_Waving(),
			};
		}

		protected override void UpdateLights(Light[] lights, int deltaTime)
		{
			_time += deltaTime;
			if (_time > _interval)
			{
				_time = 0;
				RunNextMode();
			}
			_mode.Update(lights, deltaTime);
		}
	}
}
