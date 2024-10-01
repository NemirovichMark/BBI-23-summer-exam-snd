using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task2
    {
        private Fourangle[] shapes;
        public Fourangle[] Fourangles { get { return shapes; } }
        public struct Point
        {
            private double x;
            private double y;
            public double X { get { return x; } }
            public double Y { get { return y; } }
            public Point(double[] coords)
            {
                if (coords.Length == 2)
                {
                    x = coords[0];
                    y = coords[1];
                }
            }
            public override string ToString()
            {
                return $"x = {x}, y = {y}";
            }
            public double Length(Point p)
            {
                return Math.Sqrt(Math.Pow(x - p.X, 2) + Math.Pow(y - p.Y, 2));
            }
            public static string TwoDots(Point p1, Point p2)
            {
                return $"Первая точка:\nx = {p1.X}, y = {p1.Y}\nВторая точка:\nx = {p2.X}, y = {p2.Y}\nРасстояние между точками: {p1.Length(p2)}";
            }
        }
        private Point[] points;
        public Point[] Points { get { return points; } }
        public Task2(Fourangle[] shapes)
        {
            this.shapes = shapes;
        }
        public override string ToString()
        {
            string res = "";
            foreach (Fourangle shape in shapes) { res += shape.ToString() + "\n"; }
            return res;
        }
        public void Sorting()
        {
            int n = shapes.Length;
            for (int i = 1; i < n; i++)
            {
                Fourangle val = shapes[i];
                for (int j = i - 1; j >= 0;)
                {
                    if (val.Area() < shapes[j].Area())
                    {
                        shapes[j + 1] = shapes[j];
                        j--;
                        shapes[j + 1] = val;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public abstract class Fourangle
        {
            protected Point[] points;
            public Point[] Points { get { return points; } }
            public Fourangle(Point[] points)
            {
                if (points.Length == 4)
                {
                    this.points = points;
                }
                else { this.points = new Point[4] { new Point(new double[] { 0, 0 }), new Point(new double[] { 0, 0 }), new Point(new double[] { 0, 0 }), new Point(new double[] { 0, 0 }) }; }
            }
            public abstract double Length();
            public abstract double Area();
            public override string ToString()
            {
                return $"Fourangle witn P = {Length()}, S = {Area()}";
            }
        }
        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }
            public override double Length()
            {
                return (points[0].Length(points[1]) + points[2].Length(points[3])) * 2;
            }
            public override double Area()
            {
                return Math.Pow(points[0].Length(points[1]), 2);
            }
            public override string ToString()
            {
                return $"Square witn P = {Length()}, S = {Area()}";
            }
        }
        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }
            public override double Length()
            {
                return (points[0].Length(points[1]) + points[1].Length(points[2])) * 2;
            }
            public override double Area()
            {
                return points[0].Length(points[1]) * points[1].Length(points[2]);
            }
            public override string ToString()
            {
                return $"Rectangle witn P = {Length()}, S = {Area()}";
            }
        }
    }
}