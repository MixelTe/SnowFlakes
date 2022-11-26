﻿namespace SnowFlakes
{
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

			if (isNewCreated)
			{
				ApplicationConfiguration.Initialize();
				RegSerializer.Load(KeyName, Settings);
				Application.Run(new MainForm());
			}
			else
			{
				MessageBox.Show("Уже запущено", "Снежинки");
			}
		}
	}
}