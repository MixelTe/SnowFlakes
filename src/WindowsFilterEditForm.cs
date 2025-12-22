namespace SnowFlakes;

public partial class WindowsFilterEditForm : Form
{
	private bool ignoreChangeEvent = true;
	private readonly int _filterI;
	private bool _deleted = false;

	public WindowsFilterEditForm(int filterI)
	{
		InitializeComponent();
		_filterI = filterI;
		var f = Program.Settings.Snowdrifts2DFilter[_filterI];
		CBRegex.Checked = f.Regex;
		InpValue.Text = f.Value;
		ignoreChangeEvent = false;
	}

	private void WindowsFilterEditForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape) Close();
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		var f = Program.Settings.Snowdrifts2DFilter[_filterI];
		f.Regex = CBRegex.Checked;
		f.Value = InpValue.Text;
		Close();
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		if (_deleted) return;
		_deleted = true;
		Program.Settings.Snowdrifts2DFilter.RemoveAt(_filterI);
		Close();
	}

	private void InpValue_TextChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		if (!CBRegex.Checked) return;
		LblRegexError.Visible = !Utils.IsValidRegex(InpValue.Text);
	}

	private void CBRegex_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		LblRegexError.Visible = CBRegex.Checked && !Utils.IsValidRegex(InpValue.Text);
	}
}
