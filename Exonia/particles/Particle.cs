using Exonia.particles.matter;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exonia.particles
{
    public class Particle
    {

        public double x, y;
        public double vx, vy;
        public float temperature = 100;
        public List<Particle> chemobonds = new List<Particle>();

        public bool gravoactive;
        public int lensity;
        public int mass;
        public int size;
        public int heatCapactiy;
        public int evaporationPoint;
        public int meltingPoint;
        public float density;
        public float hardness;
        public int chemobondiality;
        public int abosption;
        public int transparency;
        public int motavity;


        public Particle(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Render()
        {
            Program.renders.Add(new CircleShape(1)
            {
                FillColor = Color.Yellow,
                Origin = new Vector2f(1, 1),
                Position = new Vector2f((float)x, (float)y)
            });
        }

        public virtual void Update()
        {
            x += vx / Program.UPS;
            y += vy / Program.UPS;


            //GAS
            if (temperature > evaporationPoint)
            {
                chemobonds.Clear();
            }
            //LIQUID
            else if (temperature > meltingPoint)
            {
                foreach (Particle p in World.particles)
                {
                    if (!(p.GetType().Name == this.GetType().Name)) continue;
                    if (p == this) continue;

                    double dist = Util.Distance(this, p);
                    float distFromR = (float)Util.Distance(this, p) - 1 / density;
                    if (Math.Abs(distFromR - 1/density) < 3)
                    {
                        if (!chemobonds.Contains(p)) chemobonds.Add(p);

                        if (distFromR == 0) continue;
                        double pull = chemobondiality / (distFromR * distFromR);
                        double angle = Math.Atan2(p.y - y, p.x - x);
                        p.vx += -pull * Math.Cos(angle);
                        p.vy += -pull * Math.Sin(angle);
                    }
                    else if (dist > 1 / density)
                    {
                        chemobonds.Remove(p);
                    }
                }
            }
            //Solid
            else
            {
                foreach (Particle p in chemobonds)
                {
                    float distFromR = (float)Util.Distance(this, p) - 1 / density;
                    if (distFromR == 0) continue;
                    double pull = chemobondiality / distFromR * distFromR;
                    double angle = Math.Atan2(p.y - y, p.x - x);
                    p.vx += -pull * Math.Cos(angle);
                    p.vy += -pull * Math.Sin(angle);
                }
            }

            //APPLY GRAVITATIONAL FIELD
            foreach (Particle p in World.particles)
            {
                if (!p.gravoactive) continue;
                if (mass == 0) continue;

                double dist = Util.Distance(this, p);
                if (dist == 0) continue;
                double pull = mass / (dist * dist);
                double angle = Math.Atan2(p.y - y, p.x - x);

                if (dist < size)
                {
                    pull = -pull / 1.75f;
                }

                p.vx += -pull * Math.Cos(angle) / Program.UPS;
                p.vy += -pull * Math.Sin(angle) / Program.UPS;

            }


            //APPLY LENSOFIELD
            foreach (Particle p in World.particles)
            {
                if (!(p is Lighton)) continue;

                double dist = Util.Distance(this, p);
                if (dist == 0) continue;
                double pull = lensity / dist;
                double angle = Math.Atan2(p.y - y, p.x - x);
                p.vx += -pull * Math.Cos(angle);
                p.vy += -pull * Math.Sin(angle);
            }
        }
    }
}
