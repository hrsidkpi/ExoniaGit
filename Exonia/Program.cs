using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exonia.particles.matter;
using System.Timers;
using Exonia.particles;

namespace Exonia
{
	public class Program
	{

		public const int SIZE = 80;
		public const int WIDTH = 16 * SIZE;
		public const int HEIGHT = 9 * SIZE;

		public const float UPS = 60f;

		public static List<Drawable> renders = new List<Drawable>();

		static void Main(string[] args)
		{
			RenderWindow window = new RenderWindow(new VideoMode(WIDTH, HEIGHT), "Exonia Simultaor");
			window.SetActive();
			window.SetVerticalSyncEnabled(false);

			window.Closed += (s, e) =>
			{
				window.Close();
			};


			//pull = v^2 / R
			//pull = mass / R^2
			//mass/r=v^2
			//v = sqrt(mass/r)
			//mass = 100000
			//r = 250

			World.particles.Add(new IronMatron(500, 300));
			World.particles.Add(new IronMatron(400, 300)
			{
				vy = 0
			});
			World.particles.Add(new Particle(400, 300));
			World.particles.Add(new Particle(750, 300));

			Timer updates = new Timer(1000 / UPS);
			bool update = true;
			updates.Elapsed += (o, e) =>
			{
				update = true;
			};
			updates.Start();

			int frames = 0;
			Timer fpsCount = new Timer(1000);
			fpsCount.Elapsed += (o, e) =>
			{
				Console.WriteLine("FPS- " + frames);
				frames = 0;
			};
			fpsCount.Start();

			while (window.IsOpen)
			{
				frames++;
				if (update)
				{
					World.Update();
					update = false;
				}

				ClearWindow(window);
				World.Render();
				for (int i = 0; i < renders.Count; i++)
				{
					Drawable d = renders[i];
					window.Draw(d);
				}

				window.DispatchEvents();
				window.Display();
			};

		}

		public static void ClearWindow(RenderWindow window)
		{
			window.Clear();
			renders.Clear();
		}

	}
}
