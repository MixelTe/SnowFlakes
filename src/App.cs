using SnowFlakes.Properties;

namespace SnowFlakes;

public partial class App : ApplicationContext
{
	private readonly NotifyIcon _trayIcon;
	private SettingsForm? _settingsForm;
	private SelectZoneForm? _selectZoneForm;
	private bool _iconClicked;

	public App()
	{
		_trayIcon = new NotifyIcon()
		{
			Icon = Resources.icon,
			ContextMenuStrip = new ContextMenuStrip()
			{
				Items = {
					new ToolStripMenuItem("Пустая область", Resources.selection, [
						new ToolStripMenuItem("Выделить (ЛКМ по иконке)", Resources.select, SelectClearZone),
						new ToolStripMenuItem("Убрать (ДЛКМ по иконке)", Resources.selection_remove, RemoveClearZone),
					]),
					new ToolStripMenuItem("Управление", Resources.stop_start, [
						new ToolStripMenuItem("Остановить", Resources.stop, Stop),
						new ToolStripMenuItem("Перезапустить", Resources.restart, Restart),
						new ToolStripMenuItem("Перезагрузить настройки", Resources.reload_settings, ReloadSettings),
					]),
					new ToolStripMenuItem("Закрыть", Resources.close, Exit),
					new ToolStripMenuItem("Настройки", Resources.settings, Settings),
				}
			},
			Visible = true
		};
		_trayIcon.Click += Icon_Click;
		_trayIcon.DoubleClick += Icon_DbClick;
	}

	void Exit(object? sender, EventArgs e)
	{
		_trayIcon.Visible = false;

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
		Program.Settings.Save();
	}
	private void RemoveClearZone(object? sender, EventArgs e)
	{
		Program.Settings.ClearZone = new(0, 0, 0, 0);
		Program.Settings.Save();
	}

	private void Stop(object? sender, EventArgs e)
	{
		SnowWindow.DisposeAll();
	}
	private void Restart(object? sender, EventArgs e)
	{
		SnowWindow.DisposeAll();
		Program.Settings = new Settings();
		Program.Settings.Load();
		Program.CreateSnowWindows();
		SnowWindow.RunAll();
	}
	private void ReloadSettings(object? sender, EventArgs e)
	{
		Program.Settings = new Settings();
		Program.Settings.Load();
		SnowWindow.ReloadAll();
	}
}