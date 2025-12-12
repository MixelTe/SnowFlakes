namespace SnowFlakes
{
	class Particle
	{
		private float _x;
		private float _y;
		private float _speedX;
		private float _speedY;

		public Particle(int Width, int Height)
		{
			_x = Random.Shared.NextSingle() * Width;
			_y = Random.Shared.NextSingle() * Height;
			SetRandSpeed();
		}
		public void SetRandSpeed()
		{
			_speedX = Random.Shared.NextSingle(-Program.Settings.SpeedXMax, Program.Settings.SpeedXMax);
			_speedY = Random.Shared.NextSingle(Program.Settings.SpeedYMin, Program.Settings.SpeedYMax);
		}

		public void Draw(GameOverlay.Drawing.Graphics gfx, GameOverlay.Drawing.SolidBrush? brush, GameOverlay.Drawing.Image? img)
		{
			var R = Program.Settings.ParticleRad;
			var rect = new RectangleF(_x - R, _y - R, R * 2, R * 2);
			if (rect.IntersectsWith(Program.Settings.ClearZone)) return;

			if (img == null)
			{
				gfx.FillCircle(brush, _x, _y, R);
			}
			else
			{
				var h = rect.Width * img.Height / img.Width;
				gfx.DrawImage(img, rect.X, rect.Y, rect.Right, rect.Y + h);
			}
		}

		public void Move(int Width, int Height, Point? cursorForce, long deltaTime)
		{
			if (deltaTime > 1000) return;
			var dt = deltaTime / 40f;
			var MaxSpeedX = Program.Settings.SpeedXMax;

			var speedX = _speedX;
			if (Math.Abs(_speedX) > MaxSpeedX / 2f)
				speedX = Math.Sign(_speedX) * (MaxSpeedX - Math.Abs(_speedX));
			
			_y += _speedY * dt;
			_x += speedX * dt;
			_speedX = (_speedX + Program.Settings.SpeedX * dt).Wrap(-MaxSpeedX, MaxSpeedX);

			if (cursorForce is Point cursor)
			{
				var dx = _x - cursor.X;
				var dy = _y - cursor.Y;
				var d = dx * dx + dy * dy;
				var mds = Program.Settings.ForceD * Program.Settings.ForceD;
				if (d < mds)
				{
					var p = Program.Settings.ForcePower * (mds - d) / mds / 100;
					_x += dx * p;
					_y += dy * p;
				}
			}
			_x = _x.Wrap(0, Width);

			if (_y > Height + Program.Settings.ParticleRad ||
					Program.Settings.Snowdrifts && Program.SnowWindow?.Snowdrifts.Intersects(_x, _y) == true)
			{
				Program.SnowWindow?.Snowdrifts.Add(_x);
				_y = Random.Shared.NextSingle() * Program.Settings.SpeedYMax - Program.Settings.ParticleRad;
				_x = Random.Shared.NextSingle() * Width;
			}
			if (_y < -Program.Settings.ParticleRad)
			{
				_y = Height - 1 + Program.Settings.ParticleRad;
				_x = Random.Shared.NextSingle() * Width;
			}
		}
	}
}