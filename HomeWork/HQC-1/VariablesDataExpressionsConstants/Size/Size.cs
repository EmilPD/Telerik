namespace Shapes
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be negative or zero!");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size size, double angleOfRotation)
        {
            double newWidth = (Math.Abs(Math.Cos(angleOfRotation)) * size.Width) +
                              (Math.Abs(Math.Sin(angleOfRotation)) * size.Height);
            double newHeight = (Math.Abs(Math.Sin(angleOfRotation)) * size.Width) +
                               (Math.Abs(Math.Cos(angleOfRotation)) * size.Height);

            var newSize = new Size(newWidth, newHeight);

            return newSize;
        }
    }
}
