using SnowFlakes.Properties;

namespace SnowFlakes
{
	public partial class App : ApplicationContext
	{
		private readonly NotifyIcon trayIcon;
		private SettingsForm? _settingsForm;
		private SelectZoneForm? _selectZoneForm;
		private bool _iconClicked;

		public App()
		{
			trayIcon = new NotifyIcon()
			{
				Icon = Resources.icon,
				ContextMenuStrip = new ContextMenuStrip()
				{
					Items = {
						new ToolStripMenuItem("Закрыть", Resources.close, Exit),
						new ToolStripMenuItem("Настройки", Resources.settings, Settings),
						new ToolStripMenuItem("Пустая область", Resources.selection, new[] {
							new ToolStripMenuItem("Выделить (ЛКМ по иконке)", Resources.select, SelectClearZone),
							new ToolStripMenuItem("Убрать (ДЛКМ по иконке)", Resources.selection_remove, RemoveClearZone),
						}),
					}
				},
				Visible = true
			};
			trayIcon.Click += Icon_Click;
			trayIcon.DoubleClick += Icon_DbClick;

			Program.SnowWindow?.Run();
		}

		void Exit(object? sender, EventArgs e)
		{
			trayIcon.Visible = false;

			Application.Exit();
		}

		private void Settings(object? sender, EventArgs e)
		{
			if (_settingsForm == null || _settingsForm.IsDisposed)
				_settingsForm = new SettingsForm();
			_settingsForm.Show();
			_settingsForm.Focus();
		}

		private async void Icon_Click(object? sender, EventArgs e)
		{
			if (((MouseEventArgs)e).Button != MouseButtons.Left) return;
			if (_iconClicked) return;
			_iconClicked = true;
			await Task.Delay(SystemInformation.DoubleClickTime);
			if (!_iconClicked) return;
			_iconClicked = false;

			SelectClearZone();
		}
		private void SelectClearZone(object? sender, EventArgs e)
		{
			SelectClearZone();
		}
		private void SelectClearZone()
		{
			if (_selectZoneForm == null || _selectZoneForm.IsDisposed)
				_selectZoneForm = new();
			_selectZoneForm.Show();
		}

		private void Icon_DbClick(object? sender, EventArgs e)
		{
			if (((MouseEventArgs)e).Button != MouseButtons.Left) return;
			_iconClicked = false;
			Program.Settings.ClearZone = new(0, 0, 0, 0);
			SnowFlakes.Settings.Save();
		}
		private void RemoveClearZone(object? sender, EventArgs e)
		{
			Program.Settings.ClearZone = new(0, 0, 0, 0);
			SnowFlakes.Settings.Save();
		}
	}
}