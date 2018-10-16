using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia.particles.matter
{
	public class LensonMatron : Matron
	{
		public LensonMatron(int x, int y) : base(x, y)
		{
			gravoactive = true;
			lensity = 20;
			mass = 50;
			size = 4;
			heatCapactiy = 20;
			evaporationPoint = 50;
			density = 40;
			chemobondiality = 40;
			abosption = 0;
			transparency = 100;
			motavity = 0;
		}

		public override void Render()
		{
			Program.renders.Add(new CircleShape(5)
			{
				FillColor = Color.Blue,
				Position = new Vector2f((float)x, (float)y)
			});
		}

	}
}
