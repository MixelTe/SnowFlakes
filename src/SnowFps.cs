namespace SnowFlakes
{
	class SnowFps(int dyi = 0) : ISprite
	{
		private GameOverlay.Drawing.Font? _font;
		private GameOverlay.Drawing.SolidBrush? _brush;

		public void SetupGraphics(GameOverlay.Drawing.Graphics gfx)
		{
			_font?.Dispose();
			_font = gfx.CreateFont("Consolas", 18);
			_brush?.Dispose();
			_brush = gfx.CreateSolidBrush(Color.Tomato.ToGameOverlayColor());
		}

		public void DestroyGraphics()
		{
			_font?.Dispose(); _font = null;
			_brush?.Dispose(); _brush = null;
		}

		public void DrawGraphics(GameOverlay.Drawing.Graphics gfx, long deltaTime)
		{
			if (Program.Settings.ShowFPS)
				gfx.DrawText(_font, _brush, 58, 20 + dyi * 22, "FPS: " + gfx.FPS);
		}

		public void Reload() { }
	}
}
