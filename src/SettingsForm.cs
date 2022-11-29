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
		public SettingsForm()
		{
			InitializeComponent();
			SetFields();
		}
		private void SetFields()
		{
			InpCount.Value = Program.Settings.Particles;
			InpSize.Value = Program.Settings.ParticleSize.Width;
			BtnColor.BackColor = Program.Settings.ParticleColor;
			InpSpeedXMax.Value = (decimal)Program.Settings.SpeedXMax;
			InpSpeedX.Value = (decimal)Program.Settings.SpeedX * 10;
			var SpeedYMin = Program.Settings.SpeedYMin;
			var SpeedYMax = Program.Settings.SpeedYMax;
			InpSpeedY.Value = SpeedYMin + (SpeedYMax - SpeedYMin) / 2;
			InpSpeedYRange.Value = (SpeedYMax - SpeedYMin) / 2;
			InpD.Value = (decimal)Program.Settings.ForceD;
			InpForce.Value = (decimal)Program.Settings.ForcePower;
		}

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			Program.Settings = new Settings();
			SetFields();
			MainForm.Ins?.Reload();
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
			Program.Settings.Particles = (int)InpCount.Value;
			MainForm.Ins?.Reload();
		}
		private void Size_Change(object sender, EventArgs e)
		{
			Program.Settings.ParticleSize = new Size((int)InpSize.Value, (int)InpSize.Value);
		}
		private void Color_Change(object sender, EventArgs e) 
		{
			colorDialog.Color = Program.Settings.ParticleColor;
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Program.Settings.ParticleColor = colorDialog.Color;
				BtnColor.BackColor = Program.Settings.ParticleColor;
				MainForm.Ins?.UpdateColor();
			}
		}
		private void SpeedXMax_Change(object sender, EventArgs e) 
		{
			Program.Settings.SpeedXMax = (float)InpSpeedXMax.Value;
			MainForm.Ins?.Rerandomize();
		}
		private void SpeedX_Change(object sender, EventArgs e) 
		{
			Program.Settings.SpeedX = (float)InpSpeedX.Value / 10f;
		}
		private void SpeedY_Change(object sender, EventArgs e) 
		{
			Program.Settings.SpeedYMin = (int)(InpSpeedY.Value - InpSpeedYRange.Value);
			Program.Settings.SpeedYMax = (int)(InpSpeedY.Value + InpSpeedYRange.Value);
			MainForm.Ins?.Rerandomize();
		}
		private void Force_Change(object sender, EventArgs e) 
		{
			Program.Settings.ForcePower = (float)InpForce.Value;
		}
		private void ForceD_Change(object sender, EventArgs e) 
		{
			Program.Settings.ForceD = (float)InpD.Value;
		}
	}
}
