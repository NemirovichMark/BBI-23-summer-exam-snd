using static Task1;

public class Task2
{
    public struct Dot
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Dot(double[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
            else
            {
                X = coordinates[0];
                Y = coordinates[1];
                Z = coordinates[2];
            }
        }

        public Dot(int v1, int v2, int v3) : this()
        {
        }

        public override string ToString() => $"x = {X}, y = {Y}, z = {Z}";
    }

    public struct Vector
    {
        public Dot A { get; }
        public Dot B { get; }

        public Vector(Dot start, Dot end)
        {
            A = start;
            B = end;
        }

        public double Length()
        {
            double dx = B.X - A.X;
            double dy = B.Y - A.Y;
            double dz = B.Z - A.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public override string ToString() => $"{A}\n{B}\nLength = {Length():F2}";
    }
    public abstract class Shape
    {
        protected Dot Center { get; }
        public Vector Pointer { get; }

        public Shape(Dot center)
        {
            Center = center;
            Pointer = new Vector(Center, new Dot(0, 0, 0));
        }

        public abstract double Volume();

        public override string ToString() => $"Shape with V = {Volume():F2}";

        public virtual void CreateVector(Dot point)
        {
             Pointer = new Vector(Center, point);
        }
    }

    public class Sphere : Shape
    {
        public Sphere(Dot center) : base(center) { }

        public override double Volume() => Math.PI * Math.Pow(Pointer.Length(), 3) / 6;
    }

    public class Cube : Shape
    {
        public Cube(Dot center) : base(center) { }

        public override double Volume() => Math.Pow(Pointer.Length(), 3);
    }

    private Shape[] _shapes;
    public Shape[] Shapes => _shapes;

    public Task2(Shape[] shapes)
    {
        _shapes = shapes;
    }

    public void Sorting()
    {
    }

    public override string ToString() => string.Join("\n", _shapes.Select(s => s.ToString()));
}
