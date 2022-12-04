using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowFlakes
{
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
			BtnColor.BackColor = Program.Settings.ParticleColor;
			InpSpeedXMax.Value = (decimal)Program.Settings.SpeedXMax;
			InpSpeedX.Value = (decimal)Program.Settings.SpeedX * 10;
			var SpeedYMin = Program.Settings.SpeedYMin;
			var SpeedYMax = Program.Settings.SpeedYMax;
			InpSpeedY.Value = SpeedYMin + (SpeedYMax - SpeedYMin) / 2;
			InpSpeedYRange.Value = (SpeedYMax - SpeedYMin) / 2;
			InpD.Value = (decimal)Program.Settings.ForceD;
			InpForce.Value = (decimal)Program.Settings.ForcePower;
			switch (Program.Settings.Preset)
			{
				case 1: RBPreset1.Checked = true; break;
				case 2: RBPreset2.Checked = true; break;
				case 3: RBPreset3.Checked = true; break;
				case 4: RBPreset4.Checked = true; break;
				default: RBPreset0.Checked = true; break;
			}
			ignoreChangeEvent = false;
		}

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			Program.Settings = new Settings();
			SetFields();
			SnowWindow.Ins?.Reload();
		}
		private void OkBtn_Click(object sender, EventArgs e)
		{
			Settings.Save();
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
			SnowWindow.Ins?.Reload();
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
				Program.Settings.ParticleColor = colorDialog.Color;
				BtnColor.BackColor = Program.Settings.ParticleColor;
				SnowWindow.Ins?.UpdateColor();
			}
		}
		private void SpeedXMax_Change(object sender, EventArgs e) 
		{
			if (ignoreChangeEvent) return;
			Program.Settings.SpeedXMax = (float)InpSpeedXMax.Value;
			SetPreset0();
			SnowWindow.Ins?.Rerandomize();
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
			SnowWindow.Ins?.Rerandomize();
		}
		private void Force_Change(object sender, EventArgs e) 
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ForcePower = (float)InpForce.Value;
		}
		private void ForceD_Change(object sender, EventArgs e) 
		{
			if (ignoreChangeEvent) return;
			Program.Settings.ForceD = (float)InpD.Value;
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
			SnowWindow.Ins?.Rerandomize();
		}
		private void Preset1_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset1();
			SetFields();
			SnowWindow.Ins?.Rerandomize();
		}
		private void Preset2_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset2();
			SetFields();
			SnowWindow.Ins?.Rerandomize();
		}
		private void Preset3_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset3();
			SetFields();
			SnowWindow.Ins?.Rerandomize();
		}
		private void Preset4_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Settings.SetPreset4();
			SetFields();
			SnowWindow.Ins?.Rerandomize();
		}
		private void FPS_Change(object sender, EventArgs e)
		{
			if (ignoreChangeEvent) return;
			Program.Settings.FPS = (int)InpFPS.Value;
			SnowWindow.Ins?.SetFPS(Program.Settings.FPS);
		}
	}
}
