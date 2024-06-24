using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Variant_5.Task2;

namespace Variant_5
{
    public class Task2
    {
        public abstract class Rectangle
        {
            protected int length;
            protected int width;
            public Rectangle(int length, int width)
            {
                this.length = length;
                this.width = width;
            }
            public int A
            {
                get { return length; }
            }

            public int B
            {
                get { return width; }
            }
            public int Length()
            {
                return (length + width) * 2;
            }
            public int Area()
            {
                return length * width;
            }
            public int Compare(Rectangle second)
            {
                int firstS = this.Area();
                int secondS = second.Area();

                if (firstS > secondS) return 1;
                else if (firstS < secondS) return -1;
                else return 0;
            }
            public override string ToString()
            {
                return $"a = {length}, b = {width}, p = {Length()}, s = {Area()}";
            }
        }

        public abstract class Embrasure : Rectangle
        {
            protected string name = "Embrasure";
            private double thick;
            public double С
            {
                get { return thick; }
            }
            public Embrasure(int length, int width, double thick) : base(length, width)
            {
                this.thick = thick;
            }
            public virtual double Cost()
            {
                return length * width * 10;
            }
            public override string ToString()
            {
                return $"Type = {name}, p = {Length()}, s = {Area()}, price = {Cost():f2}";
            }
        }

        public class Window : Embrasure
        {
            private int layers;
            public int Layers
            {
                get { return layers; }
            }
            public Window(int length, int width, double thick, int layers)
                : base(length, width, thick)
            {
                name = "Window";
                this.layers = layers;
            }
            public override double Cost()
            {
                return base.Cost() + Layers / 0.3;
            }
        }

        public class Door : Embrasure
        {
            private string material;
            public string Material
            {
                get { return material; }
            }
            public Door(int length, int width, double thick, string material)
                : base(length, width, thick)
            {
                name = "Door";
                this.material = material;
            }
            public override double Cost()
            {
                double k = 1;
                if (material == "мусор") k = 1.25;
                else if (material == "пластик") k = 1.33;
                else if (material == "дерево") k = 1.5;
                return base.Cost() * k;
            }
        }
        private Embrasure[] embrasures;
        public Embrasure[] Embrasures
        {
            get { return embrasures; }
        }
        public Task2(Embrasure[] embrasures)
        {
            this.embrasures = embrasures;
        }
        public void Sorting()
        {
            int d = embrasures.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < embrasures.Length; i += d)
                {
                    Embrasure k = embrasures[i];
                    int j = i - d;

                    while (j >= 0 && embrasures[j].Cost() > k.Cost())
                    {
                        embrasures[j + d] = embrasures[j];
                        j -= d;
                    }
                    embrasures[j + d] = k;
                }
                d = d / 2;
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var embrasure in embrasures)
            {
                result += embrasure.ToString() + "\n";
            }
            return result;
        }
    }
}