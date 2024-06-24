using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{

    public class Task2
    {
        public struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double[] coordinates)
            {
                if (coordinates.Length == 2)
                {
                    X = coordinates[0];
                    Y = coordinates[1];
                }
            }

            public override string ToString()
            {
                return $"x = {X}, y = {Y}";
            }

            public double Length(Point other)
            {
                double distance = Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
                return Math.Round(distance, 2);
            }

        }

        public abstract class Fourangle
        {
            public Point[] Points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    Points = new Point[]
                    {
                        new Point(new double[] { 0, 0 }),
                        new Point(new double[] { 0, 0 }),
                        new Point(new double[] { 0, 0 }),
                        new Point(new double[] { 0, 0 })
                    };
                }
                else
                {
                    Points = points;
                }
            }

            public abstract double Perimeter();
            public abstract double Area();

            public override string ToString()
            {
                return $"{GetType().Name} with P = {Perimeter()}, S = {Area()}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Perimeter()
            {
                double side = Points[0].Length(Points[1]);
                return Math.Round(4 * side, 2);
            }

            public override double Area()
            {
                double side = Points[0].Length(Points[1]);
                return Math.Round(side * side, 2);
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Perimeter()
            {
                double length = Points[0].Length(Points[1]);
                double width = Points[1].Length(Points[2]);
                return Math.Round(2 * (length + width), 2);
            }

            public override double Area()
            {
                double length = Points[0].Length(Points[1]);
                double width = Points[1].Length(Points[2]);
                return Math.Round(length * width, 2);
            }
        }

        private Fourangle[] F;

        public Fourangle[] Fourangles => F;

        public Task2(Fourangle[] fourangles)
        {
            F = fourangles;
        }

        private void QuickSort(Fourangle[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private int Partition(Fourangle[] array, int left, int right)
        {
            double pivotValue = array[right].Area();
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j].Area() < pivotValue)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        private void Swap(Fourangle[] array, int index1, int index2)
        {
            Fourangle temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        public void Sorting()
        {
            QuickSort(F, 0, F.Length - 1);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var fourangle in F)
            {
                result += fourangle.ToString() + "\n";
            }
            return result.TrimEnd();
        }

    }
}
