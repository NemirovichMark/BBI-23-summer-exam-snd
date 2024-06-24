using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
    public class Task2
    {
        private List<Figure> figures;

        public Task2()
        {
            figures = new List<Figure>();
        }

        public Task2(List<Figure> figures)
        {
            this.figures = figures;
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        public List<Figure> Figures
        {
            get { return figures; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var figure in figures)
            {
                sb.AppendLine(figure.ToString());
            }
            return sb.ToString();
        }

        public void Sorting()
        {
            SortFigures(figures);
        }

        private void SortFigures(List<Figure> figures)
        {
            for (int i = 0; i < figures.Count - 1; i++)
            {
                for (int j = 0; j < figures.Count - i - 1; j++)
                {
                    if (figures[j].Area() > figures[j + 1].Area())
                    {
                        Figure temp = figures[j];
                        figures[j] = figures[j + 1];
                        figures[j + 1] = temp;
                    }
                }
            }
        }

        public abstract class Figure
        {
            public abstract string Distinct();
            public abstract double Area();
        }

        public class Circle : Figure
        {
            private double[] radii;

            public Circle(double[] radii)
            {
                if (radii.Length != 2 || radii.Any(r => r <= 0))
                {
                    this.radii = new double[] { 0, 0 };
                }
                else
                {
                    this.radii = radii;
                }
            }

            public override string Distinct()
            {
                return "круг/эллипс";
            }

            public override double Area()
            {
                return Math.PI * radii[0] * radii[1];
            }

            public override string ToString()
            {
                return $"Type = {Distinct()}, радиусы = ({radii[0]:F2}, {radii[1]:F2}), площадь = {Area():F2}";
            }
        }

        public class Rectangle : Figure
        {
            private double[] sides;

            public Rectangle(double[] sides)
            {
                if (sides.Length != 2 || sides.Any(s => s <= 0))
                {
                    this.sides = new double[] { 0, 0 };
                }
                else
                {
                    this.sides = sides;
                }
            }

            public override string Distinct()
            {
                return "квадрат/прямоугольник";
            }

            public override double Area()
            {
                return sides[0] * sides[1];
            }

            public override string ToString()
            {
                return $"Type = {Distinct()}, стороны = ({sides[0]:F2}, {sides[1]:F2}), площадь = {Area():F2}";
            }
        }

        public class Triangle : Figure
        {
            private int[] sides;

            public Triangle(int[] sides)
            {
                if (sides.Length != 3 || sides.Any(side => side <= 0))
                {
                    sides = new int[] { 0, 0, 0 };
                }
                else
                {
                    this.sides = sides;
                }
            }

            public int A
            {
                get { return sides[0]; }
            }

            public int B
            {
                get { return sides[1]; }
            }

            public int C
            {
                get { return sides[2]; }
            }

            public override string Distinct()
            {
                if (A == B && B == C)
                    return "равносторонний";
                else if (A == B || B == C || A == C)
                    return "равнобедренный";
                else
                    return "разносторонний";
            }

            public override double Area()
            {
                var p = (A + B + C) / 2.0;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }

            public override string ToString()
            {
                return $"Type = {Distinct()}, a = {A}, b = {B}, c = {C}, площадь = {Area():F2}";
            }
        }
    }
}