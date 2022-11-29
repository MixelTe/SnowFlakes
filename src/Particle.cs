namespace SnowFlakes
{
	class Particle
	{
		public float X;
		public float Y;
		public float SpeedX;
		public float SpeedY;


		public Particle(int Width, int Height)
		{
			X = Random.Shared.NextSingle() * Width;
			Y = Random.Shared.NextSingle() * Height;
			SpeedX = (Random.Shared.NextSingle() * 2f - 1f) * Program.Settings.SpeedXMax;
			SpeedY = Random.Shared.Next(Program.Settings.SpeedYMin, Program.Settings.SpeedYMax);
		}
		public Particle(float x, float y, float speedX, float speedY)
		{
			X = x;
			Y = y;
			SpeedX = speedX;
			SpeedY = speedY;
		}
		public void RandSpeed()
		{
			SpeedX = (Random.Shared.NextSingle() * 2f - 1f) * Program.Settings.SpeedXMax;
			SpeedY = Random.Shared.Next(Program.Settings.SpeedYMin, Program.Settings.SpeedYMax);
		}

		public void Draw(Graphics g, Brush brush)
		{
			var rect = new RectangleF(X, Y, Program.Settings.ParticleSize.Width, Program.Settings.ParticleSize.Height);
			if (!rect.IntersectsWith(Program.Settings.ClearZone))
			{
				g.FillEllipse(brush, rect);
			}
		}

		public void Move(int Width, int Height, Point? cursorForce)
		{
			Y += SpeedY;
			X += SpeedX > 0 ?
				Program.Settings.SpeedXMax - SpeedX :
				//0:
				SpeedX;
			X = (X + Width) % Width;
			SpeedX = (SpeedX + Program.Settings.SpeedXMax + Program.Settings.SpeedX) % (Program.Settings.SpeedXMax * 2) - Program.Settings.SpeedXMax;
			if (cursorForce != null)
			{
				var cursor = (Point)cursorForce;
				var d = (X - cursor.X) * (X - cursor.X) +
						(Y - cursor.Y) * (Y - cursor.Y);
				var md = Program.Settings.ForceD;
				var p = Program.Settings.ForcePower;
				if (d < md * md)
				{
					X += (md * md - d) / (md * md) * p * Math.Sign(X - cursor.X);
					X = (X + Width) % Width;
					Y += (md * md - d) / (md * md) * p * Math.Sign(Y - cursor.Y);
				}
			}
			if (Y > Height)
			{
				Y = 0;
				X = Random.Shared.NextSingle() * Width;
			}
			if (Y < 0)
			{
				Y = Height - 1;
				X = Random.Shared.NextSingle() * Width;
			}
		}

	}
}