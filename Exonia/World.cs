using Exonia.particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia
{
	public static class World
	{

		public static List<Particle> particles = new List<Particle>();

		public static void Update()
		{
			foreach(Particle p in particles)
			{
				p.Update();
			}
		}

		internal static void Render()
		{
			foreach(Particle p in particles)
			{
				p.Render();
			}
		}
	}
}
