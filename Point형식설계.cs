using System;

//public class Point
//{
//    private float x;
//    private float y;

//    public Point()
//    {
//        x = 0; y = 0;
//    }

//    public Point(float x, float y)
//    {
//        this.x = x;
//        this.y = y;
//    }

//    public static bool operator ==(in Point a, in Point b)
//    {
//        if (a.x == b.x && a.y == b.y) return true;
//        return false;
//    }
//    public static bool operator !=(in Point a, in Point b)
//    {
//        if (a.x == b.x && a.y == b.y) return false;
//        return true;
//    }

//    public static Point operator +(in Point a, in Point b)
//    {
//        Point result = new Point();
//        result.x = a.x + b.x;
//        result.y = a.y + b.y;
//        return result;
//    }
//    public static Point operator -(in Point a, in Point b)
//    {
//        Point result = new Point();
//        result.x = a.x - b.x;
//        result.y = a.y - b.y;
//        return result;
//    }
//    public static Point operator *(in Point a, in Point b)
//    {
//        Point result = new Point();
//        result.x = a.x * b.x;
//        result.y = a.y * b.y;
//        return result;
//    }
//    public static Point operator /(in Point a, in Point b)
//    {
//        Point result = new Point();
//        result.x = a.x / b.x;
//        result.y = a.y / b.y;
//        return result;
//    }

//    public override string ToString()
//    {
//        string print = $"({x},{y})";
//        return print;
//    }


//}


public class Point
{
    public double x, y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString() => $"({x}, {y})";

    public static Point operator +(in Point a, in Point b)
        => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(in Point a, in Point b)
        => new Point(a.x - b.x, a.y - b.y);
    public static Point operator *(in Point a, in Point b)
        => new Point(a.x * b.x, a.y * b.y);
    public static Point operator /(in Point a, in Point b)
        => new Point(a.x / b.x, a.y / b.y);

    public static bool operator ==(in Point a, in Point b)
        => (a.x == b.x) && (a.y == b.y);
    public static bool operator !=(in Point a, in Point b)
    => (a.x != b.x) || (a.y != b.y);

    public static Point operator ++(in Point a)
        => new Point(a.x + 1, a.y + 1);
    public static Point operator --(in Point a)
        => new Point(a.x - 1, a.y - 1);
}

class Point형식설계
{
    static void Main()
    {
        Point point1 = new Point(0, 0);
        Console.WriteLine(point1); // (0, 0) 출력

        Point point2 = new Point(10, 20);
        Console.WriteLine(point2); // (10, 20) 출력

        Console.WriteLine(point1 == point2); // false 출력
        Console.WriteLine(point1 != point2); // true 출력

        point1 = new Point(10, 20);
        point2 = new Point(100, 200);

        Point point3 = point1 + point2;
        Console.WriteLine(point3); // (110, 220) 출력

        point3 = point1 - point2;
        Console.WriteLine(point3); // (-90, -180) 출력

        point3 = point1 * point2;
        Console.WriteLine(point3); // (1000, 4000) 출력

        point3 = point1 / point2;
        Console.WriteLine(point3); // (0.1, 0.1) 출력

        Point point4 = new Point(0, 0);
        Console.WriteLine(++point4);
        Console.WriteLine(point4++);
        Console.WriteLine(point4);
    }
}
