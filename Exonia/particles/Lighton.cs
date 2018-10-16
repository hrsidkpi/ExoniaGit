using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia.particles
{
	public class Lighton : Particle
	{

		public const int LIGHT_SPEED = 150;

		public Lighton(double x, double y) : base(x, y)
		{
			gravoactive = false;
			lensity = 0;
			mass = 0;
			size = 0;
			heatCapactiy = 0;
			evaporationPoint = 0;
			density = 0.3f;
			chemobondiality = 0;
			abosption = 0;
			transparency = 100;
			motavity = 0;
		}

		public override void Update()
		{
			base.Update();

			//MAINTAIN LIGHT SPEED
			float speed = (float) Math.Sqrt(vx * vx + vy * vy);
			Vector2f nspeed = new Vector2f((float)vx, (float)vy);
			nspeed /= speed;
			nspeed *= LIGHT_SPEED;
			vx = nspeed.X;
			vy = nspeed.Y;
		}

		public override void Render()
		{
			Program.renders.Add(new CircleShape(1)
			{
				FillColor = Color.White,
				Position = new Vector2f((float)x, (float)y)
			});
		}

	}
}
