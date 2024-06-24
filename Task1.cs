using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
    public class Task1
    {
        private Variant_4.Task1.Triangle[] triangles;

        public Task1()
        {
            triangles = new Variant_4.Task1.Triangle[0];
        }

        public Task1(Variant_4.Task1.Triangle[] triangles)
        {
            this.triangles = triangles;
        }

        public void AddTriangle(int[] sides)
        {
            var triangle = new Variant_4.Task1.Triangle(sides);
            Array.Resize(ref triangles, triangles.Length + 1);
            triangles[triangles.Length - 1] = triangle;
        }

        public Variant_4.Task1.Triangle[] Triangles
        {
            get { return triangles; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var triangle in triangles)
            {
                sb.AppendLine(triangle.ToString());
            }
            return sb.ToString();
        }

     
        public void BubbleSortTriangles()
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < triangles.Length - 1; i++)
                {
                    if (triangles[i].Area() > triangles[i + 1].Area())
                    {
                       
                        Variant_4.Task1.Triangle temp = triangles[i];
                        triangles[i] = triangles[i + 1];
                        triangles[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public struct Triangle
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

            public string Distinct()
            {
                if (A == B && B == C)
                    return "равносторонний";
                else if (A == B || B == C || A == C)
                    return "равнобедренный";
                else
                    return "разносторонний";
            }

            public double Area()
            {
                var p = (A + B + C) / 2.0;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }

            public override string ToString()
            {
                return $"Type = Triangle, subtype = {Distinct()}, a = {A}, b = {B}, c = {C}, площадь = {Area():F2}";
            }
        }
    }
}
