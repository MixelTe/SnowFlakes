using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace SnowFlakes;

public partial class SettingsForm : Form
{
	private bool ignoreChangeEvent = false;
	public SettingsForm()
	{
		InitializeComponent();
		SetFields();
	}
	private void SetFields()
	{
		ignoreChangeEvent = true;

		InpCount.Value = Program.Settings.Particles;
		InpSize.Value = Program.Settings.ParticleRad;
		InpSizeRange.Value = (decimal)Program.Settings.ParticleRadRange;
		InpFPS.Value = Program.Settings.FPS;
		CBfps.Checked = Program.Settings.ShowFPS;
		BtnColor.BackColor = Program.Settings.ParticleColor;
		InpAlpha.Value = Program.Settings.ParticleColor.A;
		InpSpeedXMax.Value = (decimal)Program.Settings.SpeedXMax;
		InpSpeedX.Value = (decimal)Program.Settings.SpeedX * 10;
		var SpeedYMin = Program.Settings.SpeedYMin;
		var SpeedYMax = Program.Settings.SpeedYMax;
		InpSpeedY.Value = SpeedYMin + (SpeedYMax - SpeedYMin) / 2;
		InpSpeedYRange.Value = (SpeedYMax - SpeedYMin) / 2;
		InpD.Value = Program.Settings.ForceD;
		InpForce.Value = Program.Settings.ForcePower;
		switch (Program.Settings.Preset)
		{
			case 1: RBPreset1.Checked = true; break;
			case 2: RBPreset2.Checked = true; break;
			case 3: RBPreset3.Checked = true; break;
			case 4: RBPreset4.Checked = true; break;
			default: RBPreset0.Checked = true; break;
		}
		RBimg.Checked = true;
		switch (Program.Settings.ParticleImg)
		{
			case 0: RBimg0.Checked = true; break;
			case 1: RBimg1.Checked = true; break;
			case 2: RBimg2.Checked = true; break;
			default: RBimgCirc.Checked = true; break;
		}

		try
		{
			if (Program.Settings.ParticleImgPath != "")
				PBImg.BackgroundImage = Image.FromFile(Program.Settings.ParticleImgPath);
		}
		catch { }

		SetFilterForFileDialog();

		CBSnowdrifts.Checked = Program.Settings.Snowdrifts;
		PanelSnowdrifts.Enabled = Program.Settings.Snowdrifts;
		BtnAddSnow.Enabled = Program.Settings.Snowdrifts;
		BtnColorSD.BackColor = Program.Settings.SnowdriftsColor;
		InpAlphaSD.Value = Program.Settings.SnowdriftsColor.A;

		CBSnowdrifts2D.Checked = Program.Settings.Snowdrifts2D;
		CBSD2Smooth.Checked = Program.Settings.Snowdrifts2DSmooth;
		InpSD2Speed.Value = (decimal)Program.Settings.Snowdrifts2DSpeed;
		InpSD2Res.Value = Program.Settings.Snowdrifts2DResolution;
		InpSD2Height.Value = Program.Settings.Snowdrifts2DHeight;
		InpSD2Height.Increment = InpSD2Res.Value;
		InpSD2MaxHeight.Value = Program.Settings.Snowdrifts2DMaxHeight;
		InpSD2MaxHeight.Increment = InpSD2Res.Value;
		CBSD2Bounds.Checked = Program.Settings.Snowdrifts2DBounds;
		CBSD2Unlimited.Checked = Program.Settings.UnlimitedSnowflakes;

		CBSnowdrifts1D.Checked = Program.Settings.Snowdrifts1D;
		CBSD1Smooth.Checked = Program.Settings.Snowdrifts1DSmooth;
		InpSD1Res.Value = Program.Settings.Snowdrifts1DResolution;
		InpSD1Speed.Value = (decimal)Program.Settings.Snowdrifts1DSpeed;
		InpSD1Density.Value = (decimal)Program.Settings.Snowdrifts1DDensity;
		InpSD1Start.Value = Program.Settings.Snowdrifts1DStart;
		InpSD1Start.Enabled = !Program.Settings.Snowdrifts1DAutoStart;
		CBSD1AutoStart.Checked = Program.Settings.Snowdrifts1DAutoStart;

		CBSameColor.Checked = Program.Settings.SnowdriftsColor == Program.Settings.ParticleColor;
		PanelColorSD.Enabled = !CBSameColor.Checked;

		CBLights.Checked = Program.Settings.ChristmasLights;
		PanelLights.Enabled = Program.Settings.ChristmasLights;
		InpCLInterval.Value = Program.Settings.ChristmasLightsInterval;
		InpCLSize.Value = Program.Settings.ChristmasLightsRadius;
		InpCLAnimSpeed.Value = Program.Settings.ChristmasLightsAnimationSpeed;
		switch (Program.Settings.ChristmasLightsMode)
		{
			case 1: RBMode1.Checked = true; break;
			case 2: RBMode2.Checked = true; break;
			case 3: RBMode3.Checked = true; break;
			case 4: RBMode4.Checked = true; break;
			default: RBMode0.Checked = true; break;
		}


		ignoreChangeEvent = false;
	}

	private void ResetBtn_Click(object sender, EventArgs e)
	{
		var f = Program.Settings.Snowdrifts2DFilter;
		Program.Settings = new Settings
		{
			Snowdrifts2DFilter = f
		};
		SetFields();
		SnowWindow.ReloadAll();
	}
	private void OkBtn_Click(object sender, EventArgs e)
	{
		Program.Settings.Save();
		Close();
	}
	private void GitHub_Click(object sender, EventArgs e)
	{
		var link = "https://github.com/MixelTe/SnowFlakes";
		try
		{
			var psInfo = new ProcessStartInfo
			{
				FileName = link,
				UseShellExecute = true
			};
			Process.Start(psInfo);
			// System.Diagnostics.Process.Start(link);
		}
		catch (Exception)
		{
			Clipboard.SetText(link);
			MessageBox.Show(link + "\n\nCopied to clipboard", "SnowFlakes: Source code", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	private void Count_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Particles = (int)InpCount.Value;
		Snowflakes.UpdateParticles();
	}
	private void Size_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ParticleRad = (int)InpSize.Value;
	}
	private void InpSizeRange_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ParticleRadRange = (float)InpSizeRange.Value;
	}
	private void Color_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		colorDialog.Color = Program.Settings.ParticleColor;
		if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
		Program.Settings.ParticleColor = Color.FromArgb(InpAlpha.Value, colorDialog.Color);
		BtnColor.BackColor = colorDialog.Color;
		Snowflakes.UpdateColor();
		if (CBSameColor.Checked)
		{
			Program.Settings.SnowdriftsColor = Program.Settings.ParticleColor;
			Snowdrifts1D.UpdateColor();
			Snowdrifts2D.UpdateColor();
		}
	}
	private void Alpha_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ParticleColor = Color.FromArgb(InpAlpha.Value, Program.Settings.ParticleColor);
		Snowflakes.UpdateColor();
		if (CBSameColor.Checked)
		{
			Program.Settings.SnowdriftsColor = Program.Settings.ParticleColor;
			Snowdrifts1D.UpdateColor();
			Snowdrifts2D.UpdateColor();
		}
	}
	private void SpeedXMax_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.SpeedXMax = (float)InpSpeedXMax.Value;
		SetPreset0();
		Snowflakes.Rerandomize();
	}
	private void SpeedX_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.SpeedX = (float)InpSpeedX.Value / 10f;
		SetPreset0();
	}
	private void SpeedY_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.SpeedYMin = (int)(InpSpeedY.Value - InpSpeedYRange.Value);
		Program.Settings.SpeedYMax = (int)(InpSpeedY.Value + InpSpeedYRange.Value);
		SetPreset0();
		Snowflakes.Rerandomize();
	}
	private void Force_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ForcePower = (int)InpForce.Value;
	}
	private void ForceD_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ForceD = (int)InpD.Value;
	}
	private void SetPreset0()
	{
		Program.Settings.Preset = 0;
		ignoreChangeEvent = true;
		RBPreset0.Checked = true;
		ignoreChangeEvent = false;
	}
	private void Preset0_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Settings.SetPreset0();
		SetFields();
		Snowflakes.Rerandomize();
	}
	private void Preset1_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Settings.SetPreset1();
		SetFields();
		Snowflakes.Rerandomize();
	}
	private void Preset2_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Settings.SetPreset2();
		SetFields();
		Snowflakes.Rerandomize();
	}
	private void Preset3_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Settings.SetPreset3();
		SetFields();
		Snowflakes.Rerandomize();
	}
	private void Preset4_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Settings.SetPreset4();
		SetFields();
		Snowflakes.Rerandomize();
	}
	private void FPS_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.FPS = (int)InpFPS.Value;
		SnowWindow.SetFPSAll(Program.Settings.FPS);
	}
	private void CBfps_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ShowFPS = CBfps.Checked;
	}
	private void ImgCirc_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent || !RBimgCirc.Checked) return;
		Program.Settings.ParticleImg = -1;
		//PanelColor.Enabled = true;
		//PanelImg.Enabled = false;
	}
	private void Img_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent || !RBimg.Checked) return;
		if (RBimg0.Checked) Program.Settings.ParticleImg = 0;
		else if (RBimg2.Checked) Program.Settings.ParticleImg = 2;
		else Program.Settings.ParticleImg = 1;
		//PanelColor.Enabled = false;
		//PanelImg.Enabled = true;
	}
	private void Img1_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent || !RBimg1.Checked) return;
		Program.Settings.ParticleImg = 1;
		RBimg.Checked = true;
	}
	private void Img2_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent || !RBimg2.Checked) return;
		Program.Settings.ParticleImg = 2;
		RBimg.Checked = true;
	}
	private void Img0_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent || !RBimg0.Checked) return;
		Program.Settings.ParticleImg = 0;
		RBimg.Checked = true;
		if (Program.Settings.ParticleImgPath == "")
			ChoseImg_Click(sender, e);
	}
	private void ChoseImg_Click(object sender, EventArgs e)
	{
		var r = DialogOpenFile.ShowDialog(this);
		if (r != DialogResult.OK) return;
		if (Program.Settings.ParticleImgPath == DialogOpenFile.FileName) return;
		Program.Settings.ParticleImgPath = DialogOpenFile.FileName;
		Program.Settings.ParticleImg = 0;
		try
		{
			PBImg.BackgroundImage = Image.FromFile(DialogOpenFile.FileName);
		}
		catch
		{
			PBImg.BackgroundImage = null;
		}
		Snowflakes.UpdateImg();
		ignoreChangeEvent = true;
		RBimg0.Checked = true;
		ignoreChangeEvent = false;
	}
	private void SetFilterForFileDialog()
	{
		ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
		DialogOpenFile.Filter = "Images |" + string.Join(";", codecs.Select(el => el.FilenameExtension));
	}

	private void Snowdrifts_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts = CBSnowdrifts.Checked;
		PanelSnowdrifts.Enabled = CBSnowdrifts.Checked;
		BtnAddSnow.Enabled = CBSnowdrifts.Checked;
	}
	private void SnowdriftsSameColor_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		PanelColorSD.Enabled = !CBSameColor.Checked;
		if (CBSameColor.Checked)
			Program.Settings.SnowdriftsColor = Program.Settings.ParticleColor;
		else
			Program.Settings.SnowdriftsColor = Color.FromArgb(InpAlphaSD.Value, BtnColorSD.BackColor);
		Snowdrifts1D.UpdateColor();
		Snowdrifts2D.UpdateColor();
	}
	private void SnowdriftsColor_Click(object sender, EventArgs e)
	{
		colorDialog.Color = Program.Settings.SnowdriftsColor;
		if (colorDialog.ShowDialog(this) == DialogResult.OK)
		{
			Program.Settings.SnowdriftsColor = Color.FromArgb(InpAlphaSD.Value, colorDialog.Color);
			BtnColorSD.BackColor = colorDialog.Color;
			Snowdrifts1D.UpdateColor();
			Snowdrifts2D.UpdateColor();
		}
	}
	private void SnowdriftsAlpha_Change(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.SnowdriftsColor = Color.FromArgb(InpAlphaSD.Value, Program.Settings.SnowdriftsColor);
		Snowdrifts1D.UpdateColor();
		Snowdrifts2D.UpdateColor();
	}
	private void SnowdriftsAdd_Click(object sender, EventArgs e)
	{
		Snowdrifts1D.AddSnow();
		Snowdrifts2D.AddSnow();
	}


	private void CBSnowdrifts2D_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2D = CBSnowdrifts2D.Checked;
	}
	private void CBSD2Smooth_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DSmooth = CBSD2Smooth.Checked;
	}
	private void InpSD2Speed_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DSpeed = (float)InpSD2Speed.Value;
	}
	private void InpSD2Res_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DResolution = (int)InpSD2Res.Value;
		InpSD2MaxHeight.Increment = InpSD2Res.Value;
		InpSD2Height.Increment = InpSD2Res.Value;
		if (InpSD2Res.Value < 3) CBSD2Smooth.Checked = false;
		if (InpSD2Res.Value > 10) CBSD2Smooth.Checked = true;
		Snowdrifts2D.ChangeResolution();
	}
	private void InpSD2Height_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DHeight = (int)InpSD2Height.Value;
	}
	private void InpSD2MaxHeight_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DMaxHeight = (int)InpSD2MaxHeight.Value;
	}
	private void CBSD2Bounds_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts2DBounds = CBSD2Bounds.Checked;
	}
	private void CBSD2Unlimited_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.UnlimitedSnowflakes = CBSD2Unlimited.Checked;
	}
	private void BtnSD2Filter_Click(object sender, EventArgs e)
	{
		using var f = new WindowsFilterForm();
		Hide();
		f.ShowDialog();
		Show();
	}


	private void CBSnowdrifts1D_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1D = CBSnowdrifts1D.Checked;
	}
	private void CBSD1Smooth_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DSmooth = CBSD1Smooth.Checked;
	}
	private void InpSD1Start_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DStart = (int)InpSD1Start.Value;
	}
	private void CBSD1AutoStart_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DAutoStart = CBSD1AutoStart.Checked;
		InpSD1Start.Value = Utils.GetTaskBarBottomHeight();
		InpSD1Start.Enabled = !Program.Settings.Snowdrifts1DAutoStart;
	}
	private void InpSD1Speed_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DSpeed = (float)InpSD1Speed.Value;
	}
	private void InpSD1Res_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DResolution = (int)InpSD1Res.Value;
		if (InpSD1Res.Value < 3) CBSD1Smooth.Checked = false;
		Snowdrifts1D.ChangeResolution();
	}
	private void InpSD1Density_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.Snowdrifts1DDensity = (float)InpSD1Density.Value;
	}
	private void BtnSD1Set1_Click(object sender, EventArgs e)
	{
		CBSD1Smooth.Checked = true;
		InpSD1Res.Value = 80;
		InpSD1Speed.Value = 5;
		InpSD1Density.Value = 5;
		Snowdrifts1D.CreateSmooth();
	}
	private void BtnSD1Set2_Click(object sender, EventArgs e)
	{
		CBSD1Smooth.Checked = true;
		InpSD1Res.Value = 40;
		InpSD1Speed.Value = 5;
		InpSD1Density.Value = 5;
		Snowdrifts1D.CreateSmooth();
	}
	private void BtnSD1Set3_Click(object sender, EventArgs e)
	{
		CBSD1Smooth.Checked = false;
		InpSD1Res.Value = 1;
		InpSD1Speed.Value = 5;
		InpSD1Density.Value = 5;
		Snowdrifts1D.CreateSmooth();
	}

	private void CBLights_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLights = CBLights.Checked;
		PanelLights.Enabled = CBLights.Checked;
	}

	private void InpCLInterval_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsInterval = (int)InpCLInterval.Value;
		ChristmasLights.UpdateInterval();
	}

	private void InpCLSize_ValueChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsRadius = (int)InpCLSize.Value;
	}

	private void RBMode0_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsMode = 0;
		ChristmasLights.UpdateMode();
	}

	private void RBMode1_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsMode = 1;
		ChristmasLights.UpdateMode();
	}

	private void RBMode2_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsMode = 2;
		ChristmasLights.UpdateMode();
	}

	private void RBMode3_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsMode = 3;
		ChristmasLights.UpdateMode();
	}

	private void RBMode4_CheckedChanged(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsMode = 4;
		ChristmasLights.UpdateMode();
	}

	private void InpCLAnimSpeed_Scroll(object sender, EventArgs e)
	{
		if (ignoreChangeEvent) return;
		Program.Settings.ChristmasLightsAnimationSpeed = InpCLAnimSpeed.Value;
		ChristmasLights.UpdateSpeed();
	}
}
