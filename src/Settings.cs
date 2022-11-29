using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakes
{
	public class Settings
	{
		public int Particles = 200;
		public Size ParticleSize = new(5, 5);
		public Color ParticleColor = Color.LightBlue;
		public float SpeedXMax = 4f;
		public float SpeedX = 0.05f;
		public int SpeedYMin = 2;
		public int SpeedYMax = 6;
		public float ForceD = 200;
		public float ForcePower = 15;

		public Rectangle ClearZone = new(0, 0, 0, 0);

		public int Preset = 1;

		public static void Save()
		{
			RegSerializer.Save(Program.KeyName, Program.Settings);
		}
		public static void Load()
		{
			RegSerializer.Load(Program.KeyName, Program.Settings);
			switch (Program.Settings.Preset)
			{
				case 1: SetPreset1(); break;
				case 2: SetPreset2(); break;
			}
		}

		public static void SetPreset0() // No Preset
		{
			var s = new Settings();
			RegSerializer.Load(Program.KeyName, s);
			Program.Settings.SpeedXMax = s.SpeedXMax;
			Program.Settings.SpeedX = s.SpeedX;
			Program.Settings.SpeedYMin = s.SpeedYMin;
			Program.Settings.SpeedYMax = s.SpeedYMax;
			Program.Settings.Preset = 0;
		}
		public static void SetPreset1() // Calm
		{
			Program.Settings.SpeedXMax = 4f;
			Program.Settings.SpeedX = 0.05f;
			Program.Settings.SpeedYMin = 2;
			Program.Settings.SpeedYMax = 6;
			Program.Settings.Preset = 1;
		}
		public static void SetPreset2() // Normal
		{
			Program.Settings.SpeedXMax = 10f;
			Program.Settings.SpeedX = 0.2f;
			Program.Settings.SpeedYMin = 10;
			Program.Settings.SpeedYMax = 20;
			Program.Settings.Preset = 2;
		}
		public static void SetPreset3() // Heavy
		{
			Program.Settings.SpeedXMax = 40f;
			Program.Settings.SpeedX = 1.0f;
			Program.Settings.SpeedYMin = 20;
			Program.Settings.SpeedYMax = 30;
			Program.Settings.Preset = 3;
		}
	}
}
