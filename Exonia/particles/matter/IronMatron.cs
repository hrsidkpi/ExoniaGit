using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia.particles.matter
{
	public class IronMatron : Matron
	{
		public IronMatron(int x, int y) : base(x, y)
		{
			gravoactive = true;
			lensity = 20;
			mass = 10000;
			size = 5;
			heatCapactiy = 20;
			evaporationPoint = 1000;
            meltingPoint = 50;
			density = 1/10f;
			chemobondiality = 400;
			abosption = 0;
			transparency = 100;
			motavity = 0;
		}

		public override void Render()
		{
			Program.renders.Add(new CircleShape(15)
			{
				FillColor = new Color(100, 100, 100),
				Origin = new Vector2f(15, 15),
				Position = new Vector2f((float)x, (float)y)
			});
		}
	}
}
