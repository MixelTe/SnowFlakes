namespace SnowFlakes
{
	public partial class MainForm : Form
	{
		internal static MainForm? Ins;

		private Particle[] _points;
		private Point _pastPos;
		private SettingsForm? _settingsForm;
		private SelectZoneForm? _selectZoneForm;
		private Brush _brush;
		private bool _iconClicked;

		public MainForm()
		{
			Ins = this;
			InitializeComponent();
			Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			_brush = new SolidBrush(Program.Settings.ParticleColor);

			BackColor = Color.Green;
			TransparencyKey = Color.Green;
			_points = Array.Empty<Particle>();
			Reload();
		}
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				// turn on WS_EX_TOOLWINDOW style bit
				cp.ExStyle |= 0x80;
				return cp;
			}
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			var timer = new System.Windows.Forms.Timer();
			timer.Interval = 35;
			timer.Tick += new EventHandler(Timer_Tick);
			timer.Start();
		}
		private void Timer_Tick(object? sender, EventArgs e)
		{
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Point? cursorForce = _pastPos != Cursor.Position ? Cursor.Position : null;
			_pastPos = Cursor.Position;
			for (int i = 0; i < _points.Length; i++)
			{
				//e.Graphics.DrawEllipse(Pens.LightBlue, new Rectangle((int)_points[i].X, (int)_points[i].Y, 10, 10));
				_points[i].Draw(e.Graphics, _brush);
				_points[i].Move(Width, Height, cursorForce);
			}
			//e.Graphics.DrawEllipse(Pens.LightGreen, new Rectangle(Cursor.Position, new Size(10, 10)));
			//base.OnPaint(e);
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void Close_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Settings_Click(object sender, EventArgs e)
		{
			if (_settingsForm == null || _settingsForm.IsDisposed) 
				_settingsForm = new SettingsForm();
			_settingsForm.Show(this);
			_settingsForm.Focus();
		}

		private async void Icon_Click(object sender, EventArgs e)
		{
			if (((MouseEventArgs)e).Button != MouseButtons.Left) return;
			if (_iconClicked) return;
			_iconClicked = true;
			await Task.Delay(SystemInformation.DoubleClickTime);
			if (!_iconClicked) return;
			_iconClicked = false;

			if (_selectZoneForm == null || _selectZoneForm.IsDisposed)
				_selectZoneForm = new();
			_selectZoneForm.Show();
			_selectZoneForm.Focus();
		}

		private void Icon_DbClick(object sender, EventArgs e)
		{
			if (((MouseEventArgs)e).Button != MouseButtons.Left) return;
			_iconClicked = false;
			Program.Settings.ClearZone = new(0, 0, 0, 0);
		}

		public void Reload()
		{
			_brush = new SolidBrush(Program.Settings.ParticleColor);
			_points = new Particle[Program.Settings.Particles];
			for (int i = 0; i < _points.Length; i++)
			{
				_points[i] = new Particle(Width, Height);
			}
		}
		public void UpdateColor()
		{
			_brush = new SolidBrush(Program.Settings.ParticleColor);
		}
		public void Rerandomize()
		{
			for (int i = 0; i < _points.Length; i++)
			{
				_points[i].RandSpeed();
			}
		}
	}
}