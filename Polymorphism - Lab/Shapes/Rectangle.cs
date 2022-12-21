using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height {get;private set;}
        public double Width {get; private set;}
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2*(Height + Width);
        }
        public override void Draw()
        {
            DrawLine(Width, '*', '*');
            for (double i = 1; i < Height - 1; ++i)
                DrawLine(Width, '*', ' ');
            DrawLine(Width, '*', '*');
        }
        private void DrawLine(double width, double end, double mid)
        {
            Console.Write(end);
            for (double i = 1; i < width - 1; ++i)
                Console.Write(mid);
            Console.WriteLine(end);
        }
    }
}
