using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakes
{
	internal class ChristmasLights
	{
		private readonly int Width;
		private readonly int Height;
		private int _distance = 0;
		private Light[] _lights = { };
		private LightsMode _mode;

		public ChristmasLights(int width, int height)
		{
			Width = width;
			Height = height;
			UpdateDistance();
			_mode = new LightsMode_Waving();
		}
		
		public void Draw(GameOverlay.Drawing.Graphics gfx, GameOverlay.Drawing.SolidBrush? brush)
		{
			if (brush == null) return;
			for (int i = 0; i < _lights.Length; i++)
			{
				var d = i * _distance;
				var x = 0; var y = 0;
				if (d < Height) y = Height - d;
				else if (d < Height + Width) x = d - Height;
				else { x = Width; y = d - Height - Width; }

				var radius = Program.Settings.ChristmasLightsRadius;
				brush.Color = _lights[i].ToColor(radius);
				for (int j = 0; j < radius; j++)
				{
					gfx.FillCircle(brush, x, y, j);
				}
			}
		}

		public void Update(long deltaTime)
		{
			_mode.Update(_lights, (int)deltaTime);
		}

		public void SetMode(LightsModes mode)
		{
			switch (mode)
			{
				case LightsModes.Waving: _mode = new LightsMode_Waving(); break;
				case LightsModes.Steping: _mode = new LightsMode_Steping(); break;
				case LightsModes.Blinking: _mode = new LightsMode_Blinking(); break;
				case LightsModes.Running: _mode = new LightsMode_Running(); break;
			}
		}

		public void UpdateDistance()
		{
			_distance = Program.Settings.ChristmasLightsDistance;
			_lights = new Light[(Width + Height * 2) / _distance];
			for (int i = 0; i < _lights.Length; i++)
			{
				_lights[i] = new Light(Random.Shared.Next(255), Random.Shared.Next(255), Random.Shared.Next(255));
			}
		}

		private class Light
		{
			public int R;
			public int G;
			public int B;
			public int A;
			public int V1;

			public Light(int r, int g, int b, int a = 255)
			{
				R = r;
				G = g;
				B = b;
				A = a;
			}
			
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
						case 0: light.Set(255, 0, 0, 255 / 4 * 3, 1); break;
						case 1: light.Set(0, 255, 0, 255 / 4 * 2, 1); break;
						case 2: light.Set(0, 0, 255, 255 / 4 * 1, 1); break;
						case 3: light.Set(255, 255, 0, 255 / 4 * 0, 1); break;
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
				if (_timeInterval < 300) _timeIntervalD = 5;
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
				return (float)(Math.Sin(_time / 100f + i) + 1) / 2;
			}
		}
	}

	enum LightsModes
	{
		Waving,
		Steping,
		Blinking,
		Running,
	}
}
