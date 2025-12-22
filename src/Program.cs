namespace SnowFlakes;

internal static class Program
{
	public static readonly string KeyName = @"HKEY_CURRENT_USER\Software\MixelTe\Snowflakes";
	public static Settings Settings = new();
	public static Mutex? mutex;

	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		mutex = new Mutex(true, "SnowFlakes{F9996EF8-2B9C-4E80-89E9-57202951B768}", out var isNewCreated);

		if (!isNewCreated)
		{
			MessageBox.Show("Уже запущено", "Снежинки");
			return;
		}

		ApplicationConfiguration.Initialize();
		GameOverlay.TimerService.EnableHighPrecisionTimers();
		Settings.Load();
		CreateSnowWindows();
		SnowWindow.RunAll();
		Application.Run(new App());
		SnowWindow.DisposeAll();
	}

	public static void CreateSnowWindows()
	{
		new SnowWindow()
			.AddSprite(new Snowdrifts1D(SnowWindow.Width, SnowWindow.Height))
			.AddSprite(new Snowdrifts2D(SnowWindow.Width, SnowWindow.Height))
			.AddSprite(new Snowdrifts2DFilter())
			.AddSprite(new ChristmasLights(SnowWindow.Width, SnowWindow.Height))
			.AddSprite(new SnowflakesCount(160, 20))
			.AddSprite(new SnowFps());
		const int wc = 4;  //?Environment.ProcessorCount
		for (var i = 0; i < wc; i++)
			new SnowWindow()
				.AddSprite(new Snowflakes(SnowWindow.Width, SnowWindow.Height, wc))
				.AddSprite(new SnowFps(i + 1));
	}
}