using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlakes
{
	public class Settings
	{
		public int Particles = 200;
		public Size ParticleSize = new(5, 5);
		public Color ParticleColor = Color.LightBlue;
		public float SpeedXMax = 4f;
		public float SpeedX = 0.1f;
		public int SpeedYMin = 2;
		public int SpeedYMax = 12;
		public float ForceD = 200;
		public float ForcePower = 15;
	}
}
