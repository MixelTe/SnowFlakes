using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace SnowFlakes
{
	public partial class SettingsForm : Form
	{
		private bool ignoreChangeEvent = false;
		private Snowdrifts? _snowdrifts;
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
				case 0: RBimg0.Checked = true; PanelColor.Enabled = false; break;
				case 1: RBimg1.Checked = true; PanelColor.Enabled = false; break;
				case 2: RBimg2.Checked = true; PanelColor.Enabled = false; break;
				default: RBimgCirc.Checked = true; PanelImg.Enabled = false; break;
			}

			try
			{
				if (Program.Settings.ParticleImgPath != "")
					PBImg.BackgroundImage = Image.FromFile(Program.Settings.ParticleImgPath);
			}
			catch {}
			
			SetFilterForFileDialog();
			
			CBSnowdrifts.Checked = Program.Settings.Snowdrifts;
			PanelSnowdrifts.Enabled = Program.Settings.Snowdrifts;
			BtnAddSnow.Enabled = Program.Settings.Snowdrifts;
			CBSmooth.Checked = Program.Settings.SnowdriftsSmooth;
			BtnColorSD.BackColor = Program.Settings.SnowdriftsColor;
			InpAlphaSD.Value = Program.Settings.SnowdriftsColor.A;
			InpSDRes.Value = Program.Settings.SnowdriftsResolution;
			InpSDSpeed.Value = (decimal)Program.Settings.SnowdriftsSpeed;
			InpSDDensity.Value = (decimal)Program.Settings.SnowdriftsDensity;
			InpSDStart.Value = Program.Settings.SnowdriftsStart;
			InpSDDelay.Value = (decimal)(1000f / Program.Settings.SnowdriftsUpdateDelay);
			
			CBSameColor.Checked = Program.Settings.SnowdriftsColor == Program.Settings.ParticleColor;
			PanelColorSD.Enabled = !CBSameColor.Checked;

			ignoreChangeEvent = false;
		}

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			Program.Settings = new Settings();
			SetFields();
			Program.SnowWindow?.Reload();
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
			Program.SnowWindow?.Reload();
		}
		private void Size_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleRad = (int)InpSize.Value;
		}
		private void Color_Change(object sender, EventArgs e) 
		{
			if (ignoreChangeEvent) return;
			colorDialog.Color = Program.Settings.ParticleColor;
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Program.Settings.ParticleColor = Color.FromArgb(InpAlpha.Value, colorDialog.Color);
				BtnColor.BackColor = colorDialog.Color;
				Program.SnowWindow?.UpdateColor();
				if (CBSameColor.Checked)
				{
					Program.Settings.SnowdriftsColor = Program.Settings.ParticleColor;
					Program.SnowWindow?.UpdateColorSnowdrifts();
				}
			}
		}
		private void Alpha_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleColor = Color.FromArgb(InpAlpha.Value, Program.Settings.ParticleColor);
			Program.SnowWindow?.UpdateColor();
			if (CBSameColor.Checked)
			{
				Program.Settings.SnowdriftsColor = Program.Settings.ParticleColor;
				Program.SnowWindow?.UpdateColorSnowdrifts();
			}
		}
		private void SpeedXMax_Change(object sender, EventArgs e) 
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SpeedXMax = (float)InpSpeedXMax.Value;
			SetPreset0();
			Program.SnowWindow?.Rerandomize();
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
			Program.SnowWindow?.Rerandomize();
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
			Program.SnowWindow?.Rerandomize();
		}
		private void Preset1_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset1();
			SetFields();
			Program.SnowWindow?.Rerandomize();
		}
		private void Preset2_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset2();
			SetFields();
			Program.SnowWindow?.Rerandomize();
		}
		private void Preset3_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset3();
			SetFields();
			Program.SnowWindow?.Rerandomize();
		}
		private void Preset4_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset4();
			SetFields();
			Program.SnowWindow?.Rerandomize();
		}
		private void FPS_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.FPS = (int)InpFPS.Value;
			Program.SnowWindow?.SetFPS(Program.Settings.FPS);
		}
		private void ImgCirc_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleImg = -1;
			PanelColor.Enabled = true;
			PanelImg.Enabled = false;
		}
		private void Img_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			if (RBimg0.Checked) Program.Settings.ParticleImg = 0;
			else if (RBimg2.Checked) Program.Settings.ParticleImg = 2;
			else Program.Settings.ParticleImg = 1;
			PanelColor.Enabled = false;
			PanelImg.Enabled = true;
		}
		private void Img1_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleImg = 1;
		}
		private void Img2_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleImg = 2;
		}
		private void Img0_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ParticleImg = 0;
			if (Program.Settings.ParticleImgPath == "")
				ChoseImg_Click(sender, e);
		}
		private void ChoseImg_Click(object sender, EventArgs e)
		{
			var r = DialogOpenFile.ShowDialog(this);
			if (r == DialogResult.OK)
			{
				if (Program.Settings.ParticleImgPath != DialogOpenFile.FileName)
				{
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
					Program.SnowWindow?.UpdateSnowflakeImg();
					ignoreChangeEvent = true;
					RBimg0.Checked = true;
					ignoreChangeEvent = false;
				}
			}
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
			Program.SnowWindow?.UpdateColorSnowdrifts();
		}
		private void SnowdriftsSmooth_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsSmooth = CBSmooth.Checked;
		}
		private void SnowdriftsColor_Click(object sender, EventArgs e)
		{
			colorDialog.Color = Program.Settings.SnowdriftsColor;
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Program.Settings.SnowdriftsColor = Color.FromArgb(InpAlphaSD.Value, colorDialog.Color);
				BtnColorSD.BackColor = colorDialog.Color;
				Program.SnowWindow?.UpdateColorSnowdrifts();
			}
		}
		private void SnowdriftsAlpha_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsColor = Color.FromArgb(InpAlphaSD.Value, Program.Settings.SnowdriftsColor);
			Program.SnowWindow?.UpdateColorSnowdrifts();
		}
		private void SnowdriftsRes_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsResolution = (int)InpSDRes.Value;
			Program.SnowWindow?.Snowdrifts?.ChangeResolution();
		}
		private void SnowdriftsSpeed_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsSpeed = (float)InpSDSpeed.Value;
		}
		private void SnowdriftsDensity_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsDensity = (float)InpSDDensity.Value;
		}
		private void SnowdriftsStart_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsStart = (int)InpSDStart.Value;
		}
		private void SnowdriftsDelay_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SnowdriftsUpdateDelay = (int)(1000 / InpSDDelay.Value);
		}
		private void SnowdriftsAdd_Click(object sender, EventArgs e)
		{
			Program.SnowWindow?.Snowdrifts?.AddSnow();
		}
		private void SnowdriftsSet1_Click(object sender, EventArgs e)
		{
			CBSmooth.Checked = true;
			InpSDRes.Value = 80;
			InpSDSpeed.Value = 0.08M;
			InpSDDensity.Value = 40;
			InpSDDelay.Value = 2;
			Program.SnowWindow?.Snowdrifts?.CreateSmooth();
		}
		private void SnowdriftsSet2_Click(object sender, EventArgs e)
		{
			CBSmooth.Checked = true;
			InpSDRes.Value = 40;
			InpSDSpeed.Value = 0.16M;
			InpSDDensity.Value = 20;
			InpSDDelay.Value = 4;
			Program.SnowWindow?.Snowdrifts?.CreateSmooth();
		}
		private void SnowdriftsSet3_Click(object sender, EventArgs e)
		{
			CBSmooth.Checked = false;
			InpSDRes.Value = 1;
			InpSDSpeed.Value = 4M;
			InpSDDensity.Value = 0.4M;
			InpSDDelay.Value = 4;
			Program.SnowWindow?.Snowdrifts?.CreateSmooth();
		}
	}
}
