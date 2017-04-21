namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        private string name;

        public Figure(string name)
        {
            this.Name = this.name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public abstract double CalculateSurface();

        public abstract double CalculatePerimeter();

        public string FigureInfo()
        {
            string circleInfo = string.Format("I am a " + this.Name + ". " +
                "My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalculatePerimeter(), this.CalculateSurface());

            return circleInfo;
        }
    }
}
