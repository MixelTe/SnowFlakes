using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowFlakes
{
	public partial class SelectZoneForm : Form
	{
		private Point? _mousePos;
		private Point? _startPos;
		private readonly Pen _pen = Pens.DarkOrange;

		public SelectZoneForm()
		{
			var size = new Size(Screen.PrimaryScreen?.Bounds.Width ?? 0, Screen.PrimaryScreen?.Bounds.Height ?? 0);
			var screenshoot = new Bitmap(size.Width, size.Height);
			using var g = Graphics.FromImage(screenshoot);
			g.CopyFromScreen(0, 0, 0, 0, size);
			var font = new Font(SystemFonts.DefaultFont.FontFamily, 20f);
			g.DrawString("Выделение зоны, в которой не видно снежинок", 
				font , Brushes.Lime, 
				new PointF(size.Width / 2 - 200, size.Height - 40));

			InitializeComponent();
			Size = size;
			BackgroundImage = screenshoot;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			//base.OnMouseDown(e);
			_startPos = e.Location;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			//base.OnMouseMove(e);
			var rectPast = GetRect();
			_mousePos = e.Location;
			var rect = GetRect();
			if (rect != null)
			{
				if (rectPast != null)
					Invalidate(((Rectangle)rectPast).Inflate(4));
				Invalidate(((Rectangle)rect).Inflate(4));
				Update();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			//base.OnMouseUp(e);
			_mousePos = e.Location;
			SetZone();
			Close();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
			var rect = GetRect();
			if (rect != null)
			{
				e.Graphics.DrawRectangle(_pen, (Rectangle)rect);
			}
		}

		private Rectangle? GetRect()
		{
			if (_mousePos != null && _startPos != null)
			{
				var p1 = (Point)_startPos;
				var p2 = (Point)_mousePos;
				return new Rectangle(
					Math.Min(p1.X, p2.X),
					Math.Min(p1.Y, p2.Y),
					Math.Abs(p1.X - p2.X),
					Math.Abs(p1.Y - p2.Y)
					);
			}
			return null;
		}

		private void SetZone()
		{
			var rect = GetRect();
			if (rect != null)
			{
				Program.Settings.ClearZone = (Rectangle)rect;
				Program.Settings.Save();
			}
		}
	}
}
