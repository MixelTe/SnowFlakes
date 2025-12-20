using SnowFlakes.Properties;

namespace SnowFlakes;

class Snowflakes : ISprite
{
	private static readonly List<Snowflakes> _instances = [];
	private readonly object _lock = new();
	private readonly int _width;
	private readonly int _height;
	private readonly int _windowCount;
	private Particle[] _particles;
	private List<Particle> _particlesTemp = [];
	private Point _pastCursorPos;
	private bool _needToUpdateImg = false;
	private GameOverlay.Drawing.SolidBrush? _brush;
	private GameOverlay.Drawing.Image? _snowflake0;
	private GameOverlay.Drawing.Image? _snowflake1;
	private GameOverlay.Drawing.Image? _snowflake2;

	public Snowflakes(int width, int height, int windowCount)
	{
		_instances.Add(this);
		_width = width;
		_height = height;
		_windowCount = windowCount;
		_particles = CreateParticles();
	}
	~Snowflakes()
	{
		_instances.Remove(this);
		DestroyGraphics();
	}

	private Particle[] CreateParticles()
	{
		var particles = new Particle[Program.Settings.Particles / _windowCount];
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

		foreach (var particle in _particles)
		{
			particle.Move(gfx.Width, gfx.Height, cursorForce, deltaTime);
			particle.Draw(gfx, _brush, img);
		}
		for (int i = _particlesTemp.Count - 1; i >= 0; i--)
		{
			var particle = _particlesTemp[i];
			var renewed = particle.Move(gfx.Width, gfx.Height, cursorForce, deltaTime);
			if (renewed) _particlesTemp.RemoveAt(i);
			else particle.Draw(gfx, _brush, img);
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

	public static void UpdateColor()
	{
		foreach (var it in _instances)
		{
			if (it._brush != null)
				it._brush.Color = Program.Settings.ParticleColor.ToGameOverlayColor();
		}
	}

	public static void UpdateImg()
	{
		foreach (var it in _instances)
			it._needToUpdateImg = true;
	}

	public static void UpdateParticles()
	{
		foreach (var it in _instances)
			lock (it._lock) 
				it._particles = it.CreateParticles();
	}

	public static void Rerandomize()
	{
		foreach (var it in _instances)
			lock (it._lock)
				for (int i = 0; i < it._particles.Length; i++)
					it._particles[i].SetRandSpeed();
	}

	public static void AddTo(float x, float y)
	{
		if (_instances.Count == 0) return;
		var it = _instances.RandomItem();
		lock (it._lock) {
			if (Program.Settings.UnlimitedSnowflakes)
			{
				var p = new Particle(it._width, it._height);
				p.SetPos(x, y);
				it._particlesTemp.Add(p);
			}
			else
				it._particles.RandomItem().SetPos(x, y);
		}
	}

	public static int ParticlesCount()
	{
		var r = 0;
		foreach (var it in _instances)
			r += it._particles.Length + it._particlesTemp.Count;
		return r;
	}
}
