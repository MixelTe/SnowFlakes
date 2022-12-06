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
			RandSpeed();
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
			SpeedY = Program.Settings.SpeedYMin + Random.Shared.NextSingle() * (Program.Settings.SpeedYMax - Program.Settings.SpeedYMin);
		}

		public void Draw(GameOverlay.Drawing.Graphics gfx, GameOverlay.Drawing.SolidBrush? brush)
		{
			var rect = new RectangleF(X - Program.Settings.ParticleRad, Y - Program.Settings.ParticleRad, Program.Settings.ParticleRad * 2, Program.Settings.ParticleRad * 2);
			if (!rect.IntersectsWith(Program.Settings.ClearZone))
			{
				if (Program.Settings.ParticleImg == 1 && SnowWindow.Ins?.Snowflake1 != null)
				{
					gfx.DrawImage(SnowWindow.Ins.Snowflake1, rect.X, rect.Y, rect.Right, rect.Bottom);
				}
				else if (Program.Settings.ParticleImg == 2 && SnowWindow.Ins?.Snowflake2 != null)
				{
					gfx.DrawImage(SnowWindow.Ins.Snowflake2, rect.X, rect.Y, rect.Right, rect.Bottom);
				}
				else if (Program.Settings.ParticleImg == 0 && SnowWindow.Ins?.Snowflake0 != null)
				{
					gfx.DrawImage(SnowWindow.Ins.Snowflake0, rect.X, rect.Y, rect.Right, rect.Bottom);
				}
				else
				{
					gfx.FillCircle(brush, X, Y, Program.Settings.ParticleRad);
				}
			}
		}

		public void Move(int Width, int Height, Point? cursorForce, long deltaTime)
		{
			var dt = deltaTime / 40f;
			Y += SpeedY * dt;
			float speedX;
			if (SpeedX > 0)
			{
				speedX = SpeedX > Program.Settings.SpeedXMax / 2 ?
					Program.Settings.SpeedXMax - SpeedX :
					SpeedX;
			}
			else
			{
				speedX = SpeedX < -Program.Settings.SpeedXMax / 2 ?
					-Program.Settings.SpeedXMax - SpeedX :
					SpeedX;
			}
			X += speedX * dt;
			X = (X + Width) % Width;
			SpeedX = (SpeedX + Program.Settings.SpeedXMax + Program.Settings.SpeedX * dt) % (Program.Settings.SpeedXMax * 2) - Program.Settings.SpeedXMax;
			if (cursorForce != null)
			{
				var cursor = (Point)cursorForce;
				var d = (X - cursor.X) * (X - cursor.X) +
						(Y - cursor.Y) * (Y - cursor.Y);
				var md = Program.Settings.ForceD;
				var p = Program.Settings.ForcePower;
				if (d < md * md)
				{
					X += Math.Abs(X - cursor.X) / md * p * Math.Sign(X - cursor.X);
					X = (X + Width) % Width;
					Y += Math.Abs(Y - cursor.Y) / md * p * Math.Sign(Y - cursor.Y);
				}
			}
			if (Y > Height + Program.Settings.ParticleRad)
			{
				Y = Random.Shared.NextSingle() * Program.Settings.SpeedYMax - Program.Settings.ParticleRad;
				X = Random.Shared.NextSingle() * Width;
			}
			if (Y < -Program.Settings.ParticleRad)
			{
				Y = Height - 1 + Program.Settings.ParticleRad;
				X = Random.Shared.NextSingle() * Width;
			}
		}
	}
}