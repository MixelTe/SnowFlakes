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
		public int ParticleRad = 4;
		public Color ParticleColor = Color.FromArgb(150, Color.LightBlue);
		public int FPS = 25;
		public float SpeedXMax = 4f;
		public float SpeedX = 0.05f;
		public int SpeedYMin = 2;
		public int SpeedYMax = 6;
		public float ForceD = 200;
		public float ForcePower = 15;
		public int ParticleImg = -1; // -1 - No img; 0 - User img
		public string ParticleImgPath = "";

		public Rectangle ClearZone = Rectangle.Empty;

		public bool Snowdrifts = true;
		public bool SnowdriftsSmooth = true;
		public int SnowdriftsResolution = 50;
		public float SnowdriftsSpeed = 0.2f;
		public int SnowdriftsDensity = 20;
		public int SnowdriftsStart = 40;
		public int SnowdriftsUpdateDelay = 250;

		public int Preset = 1;


		public void Save()
		{
			RegSerializer.Save(Program.KeyName, this);
		}
		public void Load()
		{
			RegSerializer.Load(Program.KeyName, this);
			switch (Program.Settings.Preset)
			{
				case 1: SetPreset1(); break;
				case 2: SetPreset2(); break;
				case 3: SetPreset3(); break;
				case 4: SetPreset4(); break;
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
		public static void SetPreset4() // Wind
		{
			Program.Settings.SpeedXMax = 40f;
			Program.Settings.SpeedX = 1.0f;
			Program.Settings.SpeedYMin = 5;
			Program.Settings.SpeedYMax = 10;
			Program.Settings.Preset = 4;
		}
	}
}
