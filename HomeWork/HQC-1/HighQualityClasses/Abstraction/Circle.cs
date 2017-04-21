namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(string name) : base(name)
        {
            
        }

        public Circle(double radius, string name) : base(name)
        {
            this.Radius = radius;
        }
        
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius of circle must be a positive number");
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
