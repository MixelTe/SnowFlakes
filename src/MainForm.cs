namespace SnowFlakes
{
	public partial class MainForm : Form
	{
		public static MainForm? Ins;

		private RectangleF[] _points;
		private Point _pastPos;
		private SettingsForm? _settingsForm;
		private Brush _brush;

		public MainForm()
		{
			Ins = this;
			InitializeComponent();
			Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			_brush = new SolidBrush(Program.Settings.ParticleColor);

			BackColor = Color.Green;
			TransparencyKey = Color.Green;
			_points = Array.Empty<RectangleF>();
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
			var move = _pastPos != Cursor.Position;
			_pastPos = Cursor.Position;
			for (int i = 0; i < _points.Length; i++)
			{
				//e.Graphics.DrawEllipse(Pens.LightBlue, new Rectangle((int)_points[i].X, (int)_points[i].Y, 10, 10));
				e.Graphics.FillEllipse(_brush, new RectangleF(_points[i].Location, Program.Settings.ParticleSize));
				_points[i].Y += _points[i].Height;
				_points[i].X += _points[i].Width > 0 ?
					Program.Settings.SpeedXMax - _points[i].Width :
					//0:
					_points[i].Width;
				_points[i].X = (_points[i].X + Width) % Width;
				_points[i].Width = (_points[i].Width + Program.Settings.SpeedXMax + Program.Settings.SpeedX) % (Program.Settings.SpeedXMax * 2) - Program.Settings.SpeedXMax;
				if (move)
				{
					var d = (_points[i].X - _pastPos.X) * (_points[i].X - _pastPos.X) +
							(_points[i].Y - _pastPos.Y) * (_points[i].Y - _pastPos.Y);
					var md = Program.Settings.ForceD;
					var p = Program.Settings.ForcePower;
					if (d < md * md)
					{
						_points[i].X += (md * md - d) / (md * md) * p * Math.Sign(_points[i].X - _pastPos.X);
						_points[i].X = (_points[i].X + Width) % Width;
						_points[i].Y += (md * md - d) / (md * md) * p * Math.Sign(_points[i].Y - _pastPos.Y);
					}
				}
				if (_points[i].Y > Height)
				{
					_points[i].Y = 0;
					_points[i].X = Random.Shared.NextSingle() * Width;
				}
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
			_settingsForm.Show();
			_settingsForm.Focus();
		}

		public void Reload()
		{
			_brush = new SolidBrush(Program.Settings.ParticleColor);
			_points = new RectangleF[Program.Settings.Particles];
			for (int i = 0; i < _points.Length; i++)
			{
				_points[i] = new RectangleF(
					Random.Shared.NextSingle() * Width,
					Random.Shared.NextSingle() * Height,
					(Random.Shared.NextSingle() * 2f - 1f) * Program.Settings.SpeedXMax,
					Random.Shared.Next(Program.Settings.SpeedYMin, Program.Settings.SpeedYMax));
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
				_points[i] = new RectangleF(
					_points[i].X,
					_points[i].Y,
					(Random.Shared.NextSingle() * 2f - 1f) * Program.Settings.SpeedXMax,
					Random.Shared.Next(Program.Settings.SpeedYMin, Program.Settings.SpeedYMax));
			}
		}
	}
}