using Exonia.particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia
{
	public static class Util
	{

		public static double Distance(Particle p1, Particle p2)
		{
			double w = p2.x - p1.x;
			double h = p2.y - p1.y;
			return Math.Sqrt(w * w + h * h);
		}

	}
}
