namespace SnowFlakes
{
	internal static class Program
	{
		public static readonly string KeyName = @"HKEY_CURRENT_USER\Software\MixelTe\Snowflakes";
		public static Settings Settings = new();

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			RegSerializer.Load(KeyName, Settings);
			Application.Run(new MainForm());
		}
	}
}