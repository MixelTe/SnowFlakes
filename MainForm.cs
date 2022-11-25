namespace SnowFlakes
{
	public partial class MainForm : Form
	{
		private readonly int Particles = 200;
		private readonly Size ParticleSize = new(5, 5);
		private readonly float SpeedXMax = 4f;
		private readonly float SpeedX = 0.1f;
		private readonly int SpeedYMin = 3;
		private readonly int SpeedYMax = 12;
		private readonly float ForceD = 200;
		private readonly float ForcePower = 15;

		private readonly RectangleF[] _points;
		private Point _pastPos;

		public MainForm()
		{
			InitializeComponent();
			Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

			BackColor = Color.Green;
			TransparencyKey = Color.Green;

			_points = new RectangleF[Particles];
			for (int i = 0; i < _points.Length; i++)
			{
				_points[i] = new RectangleF(
					Random.Shared.NextSingle() * Width,
					Random.Shared.NextSingle() * Height,
					(Random.Shared.NextSingle() * 2f - 1f) * SpeedXMax,
					Random.Shared.Next(SpeedYMin, SpeedYMax));
			}
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
				e.Graphics.FillEllipse(Brushes.LightBlue, new RectangleF(_points[i].Location, ParticleSize));
				_points[i].Y += _points[i].Height;
				_points[i].Y %= Height;
				_points[i].X += _points[i].Width > 0 ?
					SpeedXMax - _points[i].Width :
					//0:
					_points[i].Width;
				_points[i].X = (_points[i].X + Width) % Width;
				_points[i].Width = (_points[i].Width + SpeedXMax + SpeedX) % (SpeedXMax * 2) - SpeedXMax;
				if (move)
				{
					var d = (_points[i].X - _pastPos.X) * (_points[i].X - _pastPos.X) +
							(_points[i].Y - _pastPos.Y) * (_points[i].Y - _pastPos.Y);
					var md = ForceD;
					var p = ForcePower;
					if (d < md * md)
					{
						_points[i].X += (md * md - d) / (md * md) * p * Math.Sign(_points[i].X - _pastPos.X);
						_points[i].X = (_points[i].X + Width) % Width;
						_points[i].Y += (md * md - d) / (md * md) * p * Math.Sign(_points[i].Y - _pastPos.Y);
						_points[i].Y = (_points[i].Y + Height) % Height;
					}
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
	}
}