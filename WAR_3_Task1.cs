public class Task1
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

    private Dot[] _vectors;
    public Dot[] Vectors => _vectors;

    public Task1(Vector[] vectors)
    {
        _vectors = [];
    }

    public void Sorting()
    {
        { }
    }

    public override string ToString() => string.Join("\n", _vectors.Select(v => v.ToString()));
}
