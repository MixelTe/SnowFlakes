using SnowFlakes.Properties;

namespace SnowFlakes;

class Snowflakes : ISprite
{
	private readonly int _width;
	private readonly int _height;
	private Particle[] _particles;
	private Point _pastCursorPos;
	private bool _needToUpdateImg = false;
	private GameOverlay.Drawing.SolidBrush? _brush;
	private GameOverlay.Drawing.Image? _snowflake0;
	private GameOverlay.Drawing.Image? _snowflake1;
	private GameOverlay.Drawing.Image? _snowflake2;

	public Snowflakes(int width, int height)
	{
		_width = width;
		_height = height;

		_particles = CreateParticles();
	}

	private Particle[] CreateParticles()
	{
		var particles = new Particle[Program.Settings.Particles];
		for (int i = 0; i < particles.Length; i++)
			particles[i] = new Particle(_width, _height);
		return particles;
	}

	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
	{
		_brush?.Dispose();
		_brush = gfx.CreateSolidBrush(Program.Settings.ParticleColor.ToGameOverlayColor());

		TryCreateImg(gfx);

		var ic = new ImageConverter();
		var img1 = (byte[]?)ic.ConvertTo(Resources.snowflake_simple, typeof(byte[]));
		_snowflake1?.Dispose();
		_snowflake1 = gfx.CreateImage(img1);

		var img2 = (byte[]?)ic.ConvertTo(Resources.snowflake, typeof(byte[]));
		_snowflake2?.Dispose();
		_snowflake2 = gfx.CreateImage(img2);
	}
	private void TryCreateImg(GameOverlay.Drawing.Graphics gfx)
	{
		if (Program.Settings.ParticleImgPath == "") return;
		try
		{
			_snowflake0?.Dispose();
			_snowflake0 = gfx.CreateImage(Program.Settings.ParticleImgPath);
		}
		catch
		{
			MessageBox.Show("Не получилось загрузить картинку снежинок:\n" + Program.Settings.ParticleImgPath, "Снежинки", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Program.Settings.ParticleImgPath = "";
			Program.Settings.ParticleImg = -1;
		}
	}

	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
	{
		if (_needToUpdateImg)
		{
			_needToUpdateImg = false;
			TryCreateImg(gfx);
		}

		Point? cursorForce = _pastCursorPos != Cursor.Position ? Cursor.Position : null;
		_pastCursorPos = Cursor.Position;

		GameOverlay.Drawing.Image? img = null;
		if (Program.Settings.ParticleImg == 1) img = _snowflake1;
		else if (Program.Settings.ParticleImg == 2) img = _snowflake2;
		else if (Program.Settings.ParticleImg == 0) img = _snowflake0;

		for (int i = 0; i < _particles.Length; i++)
		{
			_particles[i].Move(gfx.Width, gfx.Height, cursorForce, deltaTime);
			_particles[i].Draw(gfx, _brush, img);
		}
	}

	public void DestroyGraphics()
	{
		_brush?.Dispose(); _brush = null;
		_snowflake0?.Dispose(); _snowflake0 = null;
		_snowflake1?.Dispose(); _snowflake1 = null;
		_snowflake2?.Dispose(); _snowflake2 = null;
	}

	public void Reload()
	{
		UpdateParticles();
		UpdateColor();
	}

	public void UpdateColor()
	{
		if (_brush != null)
			_brush.Color = Program.Settings.ParticleColor.ToGameOverlayColor();
	}

	public void UpdateImg()
	{
		_needToUpdateImg = true;
	}

	public void UpdateParticles()
	{
		_particles = CreateParticles();
	}

	public void Rerandomize()
	{
		for (int i = 0; i < _particles.Length; i++)
			_particles[i].SetRandSpeed();
	}

	public void AddTo(float x, float y)
	{
		_particles[Random.Shared.Next(_particles.Length)].SetPos(x, y);
	}
}
