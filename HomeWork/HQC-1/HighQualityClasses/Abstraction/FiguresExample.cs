namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            circle.Name = "Circle";
            Console.WriteLine(circle.FigureInfo());

            Rectangle rectangle = new Rectangle(2, 3);
            rectangle.Name = "Rectangle";
            Console.WriteLine(rectangle.FigureInfo());
        }
    }
}
