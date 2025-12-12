namespace SnowFlakes;

public interface ISnowdrifts : ISprite
{
	public void UpdateColor();
	public bool AbsorbSnowflake(float x, float y);
	public void ChangeResolution();
	public void AddSnow();
	public void CreateSmooth();
}

class Snowdrifts(int width, int height) : ISprite
{
	private readonly int _width = width;
	private readonly int _height = height;
	private ISnowdrifts _sprite = CreatetSprite(width, height);

	public void DestroyGraphics() => _sprite.DestroyGraphics();
	public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime) => _sprite.DrawGraphics(gfx, deltaTime);
	public void Reload() => _sprite.Reload();
	public void SetupGraphics(GameOverlay.Drawing.Graphics gfx) => _sprite.SetupGraphics(gfx);
	public void UpdateColor() => _sprite.UpdateColor();
	public bool AbsorbSnowflake(float x, float y) => _sprite.AbsorbSnowflake(x, y);
	public void ChangeResolution() => _sprite.ChangeResolution();
	public void AddSnow() => _sprite.AddSnow();
	public void CreateSmooth() => _sprite.CreateSmooth();

	private static ISnowdrifts CreatetSprite(int width, int height)
	{
		//return new Snowdrifts2D(width, height);
		return Program.Settings.SnowdriftsType switch
		{
			1 => new Snowdrifts1D(width, height),
			_ => new Snowdrifts2D(width, height),
		};
	}
}
