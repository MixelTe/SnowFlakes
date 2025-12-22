namespace SnowFlakes;

public class Settings
{
	public int SettingsVersion = 1;

	public int Particles = 200;
	public int ParticleRad = 4;
	public float ParticleRadRange = 0.4f;
	public Color ParticleColor = Color.FromArgb(150, Color.LightBlue);
	public int FPS = 25;
	public bool ShowFPS = false;
	public float SpeedXMax = 4f;
	public float SpeedX = 0.05f;
	public int SpeedYMin = 2;
	public int SpeedYMax = 6;
	public int ForceD = 200;
	public int ForcePower = 15;
	public int ParticleImg = -1; // -1 - No img; 0 - User img
	public string ParticleImgPath = "";

	public Rectangle ClearZone = Rectangle.Empty;

	public bool Snowdrifts = true;
	public Color SnowdriftsColor = Color.FromArgb(150, Color.LightBlue);

	public bool Snowdrifts1D = true;
	public bool Snowdrifts1DSmooth = true;
	public int Snowdrifts1DResolution = 40;
	public float Snowdrifts1DSpeed = 5;
	public float Snowdrifts1DDensity = 5;
	public int Snowdrifts1DStart = 40;
	public bool Snowdrifts1DAutoStart = true;

	public bool Snowdrifts2D = true;
	public bool Snowdrifts2DSmooth = true;
	public bool Snowdrifts2DBounds = false;
	public int Snowdrifts2DResolution = 4;
	public float Snowdrifts2DSpeed = 6.5f;
	public int Snowdrifts2DHeight = 16;
	public int Snowdrifts2DMaxHeight = 16;
	public bool UnlimitedSnowflakes = true;
	public RegSerializer.SList<WindowFilter> Snowdrifts2DFilter = [
		new(false, "Создание фрагмента экрана"),
		new(false, "ShareX"),
	];

	public bool ChristmasLights = true;
	public int ChristmasLightsInterval = 60;
	public int ChristmasLightsRadius = 16;
	public int ChristmasLightsMode = 0;
	public int ChristmasLightsAnimationSpeed = 100;

	public int Preset = 1;


	public bool SnowdriftsSmooth;  // OLD
	public int SnowdriftsResolution;  // OLD
	public float SnowdriftsSpeed;  // OLD
	public float SnowdriftsDensity;  // OLD
	public int SnowdriftsStart;  // OLD

	public void Save()
	{
		RegSerializer.Save(Program.KeyName, this);
	}
	public void Load()
	{
		SettingsVersion = 0;
		RegSerializer.Load(Program.KeyName, this);
		switch (Program.Settings.Preset)
		{
			case 1: SetPreset1(); break;
			case 2: SetPreset2(); break;
			case 3: SetPreset3(); break;
			case 4: SetPreset4(); break;
		}
		UpgradeSettings();
	}
	private void UpgradeSettings()
	{
		switch (SettingsVersion)
		{
			case 0:
				SettingsVersion = 1;
				Snowdrifts1DSmooth = SnowdriftsSmooth;
				Snowdrifts1DResolution = SnowdriftsResolution;
				Snowdrifts1DSpeed = SnowdriftsSpeed * SnowdriftsResolution;
				Snowdrifts1DDensity = SnowdriftsDensity / SnowdriftsResolution * 10;
				Snowdrifts1DStart = SnowdriftsStart;
				UpgradeSettings();
				break;
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

	public class WindowFilter(bool regex, string value) : RegSerializer.ISerializable
	{
		public bool Regex = regex;
		public string Value = value;

		public WindowFilter() : this(false, "") { }

		public void Deserialize(string value)
		{
			if (string.IsNullOrWhiteSpace(value)) return;
			if (value.Length < 1) return;
			Regex = value[0] == '1';
			Value = value[1..];
		}

		public string Serialize()
		{
			return (Regex ? "1" : "0") + Value;
		}
	}
}
