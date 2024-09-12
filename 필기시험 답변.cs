using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 2번
            float GetDistance(Vector2 a, Vector2 b)
            {
                double x = a.X - b.X;
                double y = a.Y - b.Y;
                return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }
        }

        // 3번
        public Vector2 ToNormalize(Vector2 vec)
        {
            float maginitude = (float)Math.Sqrt(Math.Pow(vec.X, 2) + Math.Pow(vec.Y, 2));
            return vec / maginitude;
        }

        // 4번
        double c = Math.Sqrt(Math.Pow(p2.x - p1.x, 2.0) + Math.Pow(p2.y - p1.y, 2.0));
        double b = Math.Sqrt(Math.Pow(p1.x - p0.x, 2.0) + Math.Pow(p1.y - p0.y, 2.0));
        double d = Math.Sqrt(Math.Pow(p0.x - p2.x, 2.0) + Math.Pow(p0.y - p2.y, 2.0));
        double a = Math.Atan(c / b) * 180.0 / Math.PI;

        // 7번
        (0, -98, 1000)
    }
}

