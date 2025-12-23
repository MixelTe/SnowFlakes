namespace SnowFlakes;

public partial class WindowsFilterForm : Form
{
	private bool ignoreChangeEvent = false;
	private List<OpenWindowGetter.WindowProps> _windows = [];
	private nint? _editorFormHwnd = null;

	public WindowsFilterForm()
	{
		InitializeComponent();
		UpdateWindows();
		UpdateFilters();
	}

	private void WindowsFilterForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		Snowdrifts2DFilter.HideOverlay();
	}

	private void Timer_Tick(object sender, EventArgs e)
	{
		UpdateWindows();
	}

	private void UpdateWindows()
	{
		ignoreChangeEvent = true;
		_windows = Snowdrifts2DFilter.GetAllWindows()
			.Where(w => w.hWnd != _editorFormHwnd)
			.OrderBy(w => w.Title)
			.ToList();
		for (int i = 0; i < _windows.Count; i++)
		{
			var w = _windows[i];
			var chk =
				!Snowdrifts2DFilter.IsWindowVisible(w.Title) ? CheckState.Indeterminate :
				Snowdrifts2DFilter.IsHiddenWindow(w.hWnd) ? CheckState.Unchecked : CheckState.Checked;
			if (CBListWindows.Items.Count > i)
			{
				CBListWindows.Items[i] = w.Title;
				CBListWindows.SetItemCheckState(i, chk);
			}
			else
				CBListWindows.Items.Add(w.Title, chk);
		}
		while (CBListWindows.Items.Count > _windows.Count)
			CBListWindows.Items.RemoveAt(CBListWindows.Items.Count - 1);
		ignoreChangeEvent = false;
	}

	private void UpdateFilters()
	{
		ListFilters.Items.Clear();
		foreach (var f in Program.Settings.Snowdrifts2DFilter)
			ListFilters.Items.Add(f.Value);
	}

	private void CBListWindows_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		if (CBListWindows.SelectedIndex < 0)
			Snowdrifts2DFilter.HideOverlay();
		else
			Snowdrifts2DFilter.ShowOverlay(_windows[CBListWindows.SelectedIndex].hWnd);
	}

	private void CBListWindows_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (ignoreChangeEvent) return;
		if (e.CurrentValue == CheckState.Indeterminate) 
			e.NewValue = CheckState.Indeterminate;
		else if (e.NewValue == CheckState.Checked)
			Snowdrifts2DFilter.UnhideWindow(_windows[e.Index].hWnd);
		else
			Snowdrifts2DFilter.HideWindow(_windows[e.Index].hWnd);
	}

	private void OpenEditor(int i)
	{
		using var f = new WindowsFilterEditForm(i);
		_editorFormHwnd = f.Handle;
		f.ShowDialog();
		_editorFormHwnd = null;
		UpdateFilters();
	}

	private void CBListWindows_DoubleClick(object sender, EventArgs e)
	{
		if (CBListWindows.SelectedIndex < 0) return;
		var w = _windows[CBListWindows.SelectedIndex];
		Program.Settings.Snowdrifts2DFilter.Add(new(false, w.Title));
		OpenEditor(Program.Settings.Snowdrifts2DFilter.Count - 1);
	}

	private void MenuItemEdit_Click(object sender, EventArgs e)
	{
		if (ListFilters.SelectedIndices.Count < 1) return;
		var i = ListFilters.SelectedIndices[0];
		OpenEditor(i);
	}

	private void MenuItemDelete_Click(object sender, EventArgs e)
	{
		if (ListFilters.SelectedIndices.Count < 1) return;
		var i = ListFilters.SelectedIndices[0];
		Program.Settings.Snowdrifts2DFilter.RemoveAt(i);
		UpdateFilters();
	}

	private void ListFilters_DoubleClick(object sender, EventArgs e)
	{
		if (ListFilters.SelectedIndices.Count < 1) return;
		var i = ListFilters.SelectedIndices[0];
		OpenEditor(i);
	}
}
