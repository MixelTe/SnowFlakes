namespace SnowFlakes;

public interface ISnowdrifts : ISprite
{
	public void UpdateColor();
	public bool AbsorbSnowflake(float x, float y);
	public void ChangeResolution();
	public void AddSnow();
	public void CreateSmooth();
}

class Snowdrifts : ISprite
{
	private readonly int _width;
	private readonly int _height;
	private static ISnowdrifts? _sprite;

	public Snowdrifts(int width, int height)
	{
		_width = width;
		_height = height;
		_sprite = CreatetSprite();
	}
	~Snowdrifts()
	{
		DestroyGraphics();
	}

	public void DestroyGraphics() => _sprite?.DestroyGraphics();
	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime) => _sprite?.DrawGraphics(gfx, deltaTime);
	public void Reload() => _sprite?.Reload();
	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx) => _sprite?.SetupGraphics(gfx);
	public static void UpdateColor() => _sprite?.UpdateColor();
	public static bool AbsorbSnowflake(float x, float y) => _sprite?.AbsorbSnowflake(x, y) ?? false;
	public static void ChangeResolution() => _sprite?.ChangeResolution();
	public static void AddSnow() => _sprite?.AddSnow();
	public static void CreateSmooth() => _sprite?.CreateSmooth();

	private ISnowdrifts CreatetSprite()
	{
		//return new Snowdrifts2D(_width, _height);
		return Program.Settings.SnowdriftsType switch
		{
			1 => new Snowdrifts1D(_width, _height),
			_ => new Snowdrifts2D(_width, _height),
		};
	}
}
